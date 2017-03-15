using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private MapView _gameMapView;
        private Player _player;
        private World _world;
        private bool _playingGame;
        private MenuOptions _currentScreen;

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
            _gameMapView = new MapView(_player, _world);
            _playingGame = true;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop() {
            MenuOptions playerMenuChoice = MenuOptions.None;

            //
            // display splash screen
            //
            _playingGame = true;
            //_gameConsoleView.DisplayIntroScreen();
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
            _gameConsoleView.DisplayGamePlayScreen("Part One", Text.IntroductionP1(),ActiveMenu.NoMenu, "");
            _gameConsoleView.GetContinueKey();

            //
            // Initialize the player's stats
            // 
            InitializePlayerStats();

            //
            // Display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Part Two", Text.IntroductionP2(), ActiveMenu.NoMenu, "");
            _gameConsoleView.GetContinueKey();

            //
            // Initialize the player's spells
            // 
            _gameConsoleView.DisplayGamePlayScreen("Book of Necromancy", "This is where you will choose your starting spells", ActiveMenu.NoMenu, "");
            _gameConsoleView.GetContinueKey();
            //InitializePlayerSpells();

            //
            // Display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Part Three", Text.IntroductionP3(), ActiveMenu.NoMenu, "");
            _gameConsoleView.GetContinueKey();


            //
            // Prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_world.GetLocationByID(1)), ActiveMenu.FullMenu, "");

            //
            // Game loop
            //
            while (_playingGame) {
                
                playerMenuChoice = _gameConsoleView.GetMenuChoice(ActiveMenu.FullMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (playerMenuChoice) {
                    case MenuOptions.None:
                        break;

                    case MenuOptions.WorldMap:
                        _gameMapView.DisplayWorldMap();
                        break;

                    case MenuOptions.LocalMap:
                        _gameConsoleView.DisplayCurrentLocationInfo();
                        break;

                    case MenuOptions.Character:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;

                    case MenuOptions.Inventory:
                        _gameConsoleView.DisplayCurrentLocationInfo();
                        break;

                    case MenuOptions.Settings:
                        _playingGame = false;
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

            _player.PosX = 0;
            _player.PosY = 0;
            _player.MoveSpeed = 1;
            _player.Name = player.Name;
            _player.Species = Entity.SpeciesType.Human;
            _player.Strength = player.Strength;
            _player.Dexterity = player.Dexterity;
            _player.Constitution = player.Constitution;
            _player.Intelligence = player.Intelligence;
            _player.Wisdom = player.Wisdom;
            _player.Charisma = player.Charisma;
        }

        #endregion
    }
}
