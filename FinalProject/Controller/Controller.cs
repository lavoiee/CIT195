using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {


    //TODO Admin menu
        // List all locations
        // List all objects
        // ** Create/edit an object
        // ** Edit a location



/*
        Homework


get max location? Add bounds?
Manage game loop to handle inputs
track visited locations
add hasVisited method to entity class
add health and status bar to the side menu

        add forests
        add mazes

partial classes - separate assets by types
	text class - separate into story, menu, and gameplay
    
*/
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _player;
        private World _world;
        private bool back = false;

        private Location _currentLocation;
        private List<Location> _locationsVisited;

        private bool _playingGame;
        private bool _inBattle;
        private Npc _opponent;

        #endregion

        #region CONSTRUCTORS

        public Controller() {
            //
            // Setup all of the objects in the game
            //
            InitializeGame();

            //
            // Begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame() {
            _player = new Player();
            _world = new World();
            _gameConsoleView = new ConsoleView(_player, _world);
            _playingGame = true;
            _locationsVisited = new List<Location>();
            Text.InitializeRandomBiomes();

            //Add initial item(s) to player
            AddItemToInventory(_world.GetGameObjectById(1) as CollectibleObject);
            AddItemToInventory(_world.GetGameObjectById(2) as CollectibleObject);
            AddItemToInventory(_world.GetGameObjectById(3) as CollectibleObject);
            
            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop() {
            MenuOptions playerMenuChoice = MenuOptions.None;
            Menu currentMenu = ActiveMenu.NoMenu;
            bool devMode = false;

            if (!devMode) {
                //
                // display splash screen
                //
                _playingGame = _gameConsoleView.DisplayIntroScreen();
                //_gameConsoleView.DisplayAnimation();


                //
                // player chooses to quit
                //
                if (!_playingGame) {
                    /// TODO animate outro-------------------------------------------------------------------------------------------------------------
                    Environment.Exit(1);
                }
                //
                // Display introductory message
                //
                //_gameConsoleView.DisplayGamePlayScreen("Part One", Text.IntroductionP1(),ActiveMenu.NoMenu);
                //_gameConsoleView.GetContinueKey();

                //
                // Initialize the player's stats
                // 
                InitializePlayerStats();

                //
                // Display introductory message
                //
                _gameConsoleView.DisplayGamePlayScreen("Part Two", Text.IntroductionP2(), ActiveMenu.NoMenu);
                _gameConsoleView.GetContinueKey();

                //
                // Initialize the player's spells
                // 
                _gameConsoleView.DisplayGamePlayScreen("Book of Necromancy", "This is where you will choose your starting spells", ActiveMenu.NoMenu);
                _gameConsoleView.GetContinueKey();
                //InitializePlayerSpells();

                //
                // Display introductory message
                //
                _gameConsoleView.DisplayGamePlayScreen("Part Three", Text.IntroductionP3(), ActiveMenu.NoMenu);
                _gameConsoleView.GetContinueKey();

                //
                // Prepare game play screen
                //
                _gameConsoleView.DisplayWorldMap(true);
            } else {
                _gameConsoleView.DisplayWorldMap();
            }

            //
            // Game loop
            //
            while (_playingGame) {
                UpdateGameStatus();

                _currentLocation = _world.GetLocationByCoords(_player.xPos, _player.yPos);
                _locationsVisited.Add(_currentLocation);

                playerMenuChoice = _gameConsoleView.GetMenuEscape(_gameConsoleView.CurrentMenu);
                if (playerMenuChoice == MenuOptions.None) {
                    playerMenuChoice = _gameConsoleView.GetMenuChoice(_gameConsoleView.CurrentMenu, back);
                }
                back = false;
                _gameConsoleView.MenuEscape = 0;
                _gameConsoleView.CurrentMenuChoice = playerMenuChoice;
                //
                // choose an action based on the user's menu choice
                //
                switch (playerMenuChoice) {
                    case MenuOptions.None:
                        break;



                    // Main Menu
                    case MenuOptions.WorldMap:
                        _gameConsoleView.DisplayWorldMap();
                        break;

                    case MenuOptions.Explore:
                        _gameConsoleView.DisplayCurrentLocationInfo();
                        break;

                    case MenuOptions.Character:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;

                    case MenuOptions.Inventory:
                        _gameConsoleView.DisplayInventory(_player.Inventory, true);
                        break;

                    case MenuOptions.Settings:
                        _gameConsoleView.DisplaySettings();
                        break;



                    // Settings
                    case MenuOptions.DevMenu:
                        _gameConsoleView.DisplayDevMenu();
                        break;

                    case MenuOptions.Back:
                        back = true;
                        break;



                    // Player Actions
                    case MenuOptions.LookAt:
                        _gameConsoleView.DisplayLookAt();
                        break;

                    case MenuOptions.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;



                    // Developer Actions
                    case MenuOptions.ListLocations:
                        _gameConsoleView.DisplayListOfAllLocations();
                        break;

                    case MenuOptions.ListObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case MenuOptions.ListNpcs:
                        _gameConsoleView.DisplayListOfAllNpcs();
                        break;

                    default:
                        break;
                }

            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializePlayerStats() {
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            _player.xPos = 1332;
            _player.yPos = 866;
            _player.MoveSpeed = 1;
            _player.Name = player.Name;
            _player.Species = Entity.SpeciesType.Human;
            _player.Strength = player.Strength;
            _player.Dexterity = player.Dexterity;
            _player.Constitution = player.Constitution;
            _player.Intelligence = player.Intelligence;
            _player.Wisdom = player.Wisdom;
            _player.Charisma = player.Charisma;

            // TODO add racial base values
            // TODO first rethink the player/race/entity structure
            _player.MaxHealth = 30 + _player.Constitution * 3;
            _player.Health = _player.MaxHealth / 4;
        }

        private void AddItemToInventory(CollectibleObject item) {
            _player.Inventory.Add(item);
            item.Owner = _player;

        }

        private void UpdateGameStatus() {
            _gameConsoleView.DisplaySideWindowInformation();

            CheckLocation(_player);

            // TODO implement this for all entities
            //_player.HealthRegen();

        }

        private void CheckLocation(Entity entity) {
            foreach (Npc npc in _world.Npcs) {
                if (npc.xPos == entity.xPos)
                    if (npc.yPos == entity.yPos)
                        if (npc.Encounter(entity) == NpcActions.Attack) {
                            _inBattle = true;
                            _gameConsoleView.DisplayBattleScreen(npc);
                            break;
                        }

            }
        }

        #endregion
    }
}
