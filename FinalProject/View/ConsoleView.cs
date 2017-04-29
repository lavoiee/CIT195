using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView {
        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _player;
        World _world;
        Menu _currentMenu;
        MenuOptions _currentMenuChoice = MenuOptions.WorldMap;
        List<MenuOptions> _lastMenuChoice;
        string debug = "";
        int _menuEscape = -1;
        MenuOptions _overrideMenu;
        
        #endregion

        #region PROPERTIES

        public Menu CurrentMenu {
            get { return _currentMenu; }
            set { _currentMenu = value; }
        }

        public int MenuEscape {
            get { return _menuEscape; }
            set { _menuEscape = value; }
        }

        public MenuOptions OverrideMenu {
            get { return _overrideMenu; }
            set { _overrideMenu = value; }
        }

        public MenuOptions CurrentMenuChoice {
            get { return _currentMenuChoice; }
            set { _currentMenuChoice = value; }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, World gameWorld) {
            _player = gamePlayer;
            _world = gameWorld;
            _lastMenuChoice = new List<MenuOptions>();
            _lastMenuChoice.Add(MenuOptions.WorldMap);

            InitializeDisplay();
            InitializeMap();
        }

        #endregion

        #region Methods

        #region Window drawing
        /// <summary>
        /// Display all of the elements on the gameplay screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu) {
            _currentMenu = menu;

            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            DisplayMenuBar(menu);
            DisplayMainBox(messageBoxHeaderText, messageBoxText);
            DisplaySideWindow(menu);
            //DisplayInputBox();
            Debug();
        }

        /// <summary>
        /// Initialize the console window settings
        /// </summary>
        private static void InitializeDisplay() {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The Hw Project";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }
        private void DisplayMenuBar(Menu menu) {



            //
            // display menu bar background
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBarPositionLeft + 2, ConsoleLayout.MenuBarPositionTop);
            //Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBarWidth));
            Console.Write(@"║".PadRight(ConsoleLayout.MenuBarWidth - 2) + "║");

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int i = 10;

            foreach (KeyValuePair<int, MenuOptions> menuChoice in menu.MenuChoices) {
                if (menuChoice.Value != MenuOptions.None) {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBarPositionLeft + i, ConsoleLayout.MenuBarPositionTop);
                    i += (ConsoleLayout.MenuBarWidth - 4) / 5;
                    Console.Write($"|║  ({menuChoice.Key}) {formatedMenuChoice}  ║|");
                }
            }
        }
        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplaySideWindow(Menu menu) {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // Display side window border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.SideWindowPositionTop,
                ConsoleLayout.SideWindowPositionLeft,
                ConsoleLayout.SideWindowWidth,
                ConsoleLayout.SideWindowHeight);

            //
            // Display side window header
            //
            Console.BackgroundColor = ConsoleTheme.MenuSelectionBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuSelectionForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, ConsoleLayout.SideWindowPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.SideWindowWidth - 4));
        }

        /// <summary>
        /// display the text in the main box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMainBox(string headerText, string messageText) {
            //
            // Display the outline for the main window
            //
            Console.BackgroundColor = ConsoleTheme.MainBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MainBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MainBoxPositionTop,
                ConsoleLayout.MainBoxPositionLeft,
                ConsoleLayout.MainBoxWidth,
                ConsoleLayout.MainBoxHeight);

            //
            // Display main window header
            //
            Console.BackgroundColor = ConsoleTheme.MainBoxHeaderBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MainBoxHeaderForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + 2, ConsoleLayout.MainBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center($"[  {headerText}  ]", ConsoleLayout.MainBoxWidth - 4));

            //
            // Display the text for the main window
            //
            Console.BackgroundColor = ConsoleTheme.MainBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MainBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MainBoxWordWrap(messageText, ConsoleLayout.MainBoxWidth - 4);

            int startingRow = ConsoleLayout.MainBoxPositionTop + 5;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines) {
                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + 6, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// Display an interactive menu in the main window of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private int[] DisplayInteractiveMenuBox(Menu menu, string heading) {
            //
            // display menu choices
            //
            int topRow;
            int currentSelection = 1;
            int remainingPoints = 10;
            bool complete = false;
            int[] info = new int[menu.InteractiveMenuChoices.Count];
            Console.CursorVisible = false;

            for (int i = 0; i < info.Length; i++) {
                info[i] = 5;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - (heading.Length + 8) / 2, ConsoleLayout.MainBoxPositionTop + 6);
            Console.Write(@"-=  " + heading + @"  =-");


            while (!complete) {
                topRow = ConsoleLayout.MainBoxPositionTop + 9;
                foreach (KeyValuePair<int, string> menuChoice in menu.InteractiveMenuChoices) {
                    string indicator = "   ";
                    if (menuChoice.Key == currentSelection)
                        indicator = " - ";
                    string formattedMenuChoice = indicator + ConsoleWindowHelper.ToLabelFormat(menuChoice.Value) + indicator;
                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 19, topRow += 2);
                    Console.Write($"{formattedMenuChoice}".PadRight(30) + $"< {info[menuChoice.Key - 1]} > ");
                }

                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 10, topRow += 4);
                Console.Write($"Points remaining: {remainingPoints}");

                ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyPressedInfo.Key;
                if (keyPressed == ConsoleKey.Enter) {
                    complete = true;
                }
                if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.S) {
                    if (currentSelection < menu.InteractiveMenuChoices.Count)
                        currentSelection += 1;
                }
                if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.W) {
                    if (currentSelection > 1)
                        currentSelection -= 1;
                }
                if (keyPressed == ConsoleKey.LeftArrow || keyPressed == ConsoleKey.A) {
                    if (info[currentSelection - 1] > 1) {
                        info[currentSelection - 1] -= 1;
                        remainingPoints += 1;
                    }
                }
                if ((keyPressed == ConsoleKey.RightArrow || keyPressed == ConsoleKey.D) && remainingPoints > 0) {
                    if (info[currentSelection - 1] < 10) {
                        info[currentSelection - 1] += 1;
                        remainingPoints -= 1;
                    }
                }

            }
            return info;
        }

        public void DropObject(CollectibleObject droppedObject) {
            /// Remove the object from inventory and set the location to the current value
            _player.Inventory.Remove(droppedObject);
            droppedObject.Owner = null;
            droppedObject.xPos = _player.xPos;
            droppedObject.yPos = _player.yPos;
        }

        // TODO This sucks, fix it
        public void DestroyObject(CollectibleObject item) {
            if (item.Owner == _player)
                _player.Inventory.Remove(item);
            _world.GameObjects.Remove(item);
        }
        public void PickUpObject(CollectibleObject grabbedObject) {
            /// Remove the object from inventory and set the location to the current value
            _player.Inventory.Add(grabbedObject);
            grabbedObject.Owner = _player;
        }
        public void UseObject(CollectibleObject item) {
            if (item.Type == ItemType.Consumable) {
                _player.Health += item.HealingValue;
                string message = "";
                if (item.HealingValue > 0)
                    message = $"Healed {item.HealingValue} hitpoints";
                else
                    message = $"Took {Math.Abs(item.HealingValue)} points of damage";

                DestroyObject(item);
                DisplayGamePlayScreen("Inventory", "", ActiveMenu.FullMenu);
                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.WindowBorderSide, ConsoleLayout.MainBoxPositionTop + 12);
                Console.Write(ConsoleWindowHelper.Center(message, ConsoleLayout.MainBoxWidth - 4));
                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.WindowBorderSide, ConsoleLayout.MainBoxPositionTop + 14);
                Console.Write(ConsoleWindowHelper.Center("Press any key to continue", ConsoleLayout.MainBoxWidth - 4));
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox() {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt) {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage) {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox() {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++) {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }


        #endregion

        #region Information drawing------------------------------------------------------------------------

        public void DisplaySideWindowInformation() {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.SideWindowPositionTop + 3;
            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow - 1);
            Console.Write(new string('-',ConsoleLayout.SideWindowWidth-4));
            DisplayPlayerInfo(topRow);
            DisplayLocationInfo(topRow+25);
        }

        public void DisplayPlayerInfo(int topRow) {
            // Draw player info
            if (_player.MaxHealth != 0) {
                Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow + 1);
                Console.Write(ConsoleWindowHelper.Center($"Health", ConsoleLayout.SideWindowWidth - 4));
                if (_player.Health / (float)_player.MaxHealth < .1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else if (_player.Health / (float)_player.MaxHealth < .25)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow += 2);
                Console.Write(ConsoleWindowHelper.Center($"{_player.Health}/{_player.MaxHealth}", ConsoleLayout.SideWindowWidth - 4));
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow += 3);
            Console.Write(ConsoleWindowHelper.Center("Experience", ConsoleLayout.SideWindowWidth - 4));
            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow += 1);
            Console.Write(ConsoleWindowHelper.Center($"{_player.Experience}", ConsoleLayout.SideWindowWidth - 4));
        }

        public void DisplayLocationInfo(int topRow) {
            // Draw location info
            Location currentLocation = _world.GetLocationByCoords(_player.xPos, _player.yPos);

            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow += 2);
            Console.Write(ConsoleWindowHelper.Center(new string('-', ConsoleLayout.SideWindowWidth - 4), ConsoleLayout.SideWindowWidth - 4));
            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow += 2);
            Console.Write(ConsoleWindowHelper.Center(currentLocation.CommonName, ConsoleLayout.SideWindowWidth - 4));
            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow += 2);
            Console.Write(ConsoleWindowHelper.Center($"({currentLocation.xCoord}, {currentLocation.yCoord})", ConsoleLayout.SideWindowWidth - 4));
            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, topRow += 4);
            List<CollectibleObject> items = _world.GetCollectableObjectsByLocation(_player.xPos, _player.yPos);
            bool valid = false;
            foreach (CollectibleObject item in items) {
                if (item.Owner == null)
                    valid = true;
            }
            if (items.Count != 0 && valid)
                Console.Write(ConsoleWindowHelper.Center("!", ConsoleLayout.SideWindowWidth - 4));
            else
                Console.Write(ConsoleWindowHelper.Center(" ", ConsoleLayout.SideWindowWidth - 4));
        }

        #endregion

        #region Map drawing

        public void InitializeMap() {
            MapWindowControl.InitializeMaps();
        }

        public void DisplayWorldMap() {
            DisplayWorldMap(false);
        }

        public void DisplayWorldMap(bool zooming) {
            bool drawing = true;
            DisplayGamePlayScreen("World Map", "", ActiveMenu.FullMenu);
            MapWindowControl.Move(0, 0, 0);
            MapWindowControl.DrawScreen();
            if (zooming) {
                System.Threading.Thread.Sleep(1000);
                int zoom = MapWindowControl.zoomLevels;
                MapWindowControl.Zoom = zoom;
                while (zoom > 0) {
                    MapWindowControl.Move(0, 0, -1);
                    MapWindowControl.DrawScreen();
                    zoom -= 1;
                }
            }
            while (drawing) {
                DrawPlayerAndItems();
                drawing = MovePlayer();
                MapWindowControl.DrawScreen();
                DrawPlayerAndItems();
            }
        }

        public void DrawPlayerAndItems() {
            DisplaySideWindowInformation();
            DisplayNearbyObjects();
            DisplayNearbyLocations();
            MapWindowControl.ChangeColors(MapWindowControl.GetHeightAtPosition(), "terrain", "player");
            Console.SetCursorPosition(MapWindowControl.WindowLeft + MapWindowControl.WindowWidth / 2, MapWindowControl.WindowTop + MapWindowControl.WindowHeight / 2);
            Console.Write("X");
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayNearbyObjects() {
            foreach (CollectibleObject item in _world.GameObjects)
                if (MapWindowControl.GetDistance(item.xPos, item.yPos, _player.xPos, _player.yPos) < 20 && item.Owner == null) {
                    int[] tempPos = WorldPosToScreenPos(item.xPos, item.yPos);
                    Console.SetCursorPosition(tempPos[0], tempPos[1]);
                    tempPos = WorldPosToMapDrawPos(item.xPos, item.yPos);
                    MapWindowControl.ChangeColors(MapWindowControl.GetHeightAtPosition(tempPos[0], tempPos[1]), "terrain", "item");
                    Console.Write("!");
                }
        }

        public void DisplayNearbyLocations() {
            foreach (Location location in _world.Locations)
                if (MapWindowControl.GetDistance(location.xCoord, location.yCoord, _player.xPos, _player.yPos) < 20 && location.Generic == false) {
                    int[] tempPos = WorldPosToScreenPos(location.xCoord, location.yCoord);
                    Console.SetCursorPosition(tempPos[0], tempPos[1]);
                    tempPos = WorldPosToMapDrawPos(location.xCoord, location.yCoord);
                    MapWindowControl.ChangeColors(MapWindowControl.GetHeightAtPosition(tempPos[0], tempPos[1]), "terrain", "location");
                    Console.Write("^");
                }
        }

        public int[] WorldPosToScreenPos(int x, int y) {
            int[] screenPos = new int[2];
            screenPos[0] = MapWindowControl.WindowLeft + MapWindowControl.WindowWidth / 2 - (_player.xPos - x);
            screenPos[1] = MapWindowControl.WindowTop + MapWindowControl.WindowHeight / 2 + (_player.yPos - y);

            return screenPos;
        }

        public int[] WorldPosToMapDrawPos(int x, int y) {
            int[] screenPos = new int[2];
            screenPos[0] = MapWindowControl.WindowWidth / 2 - (_player.xPos - x);
            screenPos[1] = MapWindowControl.WindowHeight / 2 + (_player.yPos - y);

            return screenPos;
        }

        public bool MovePlayer() {
            _player.HealthRegen();
            ConsoleKey keyPressed = Console.ReadKey().Key;

            int moveX = 0;
            int moveY = 0;
            int zoom = 0;

            switch (keyPressed) {
                case ConsoleKey.A:
                    moveX = -_player.MoveSpeed;
                    break;
                case ConsoleKey.D:
                    moveX = _player.MoveSpeed;
                    break;
                case ConsoleKey.W:
                    moveY = _player.MoveSpeed;
                    break;
                case ConsoleKey.S:
                    moveY = -_player.MoveSpeed;
                    break;
                case ConsoleKey.E:
                    zoom = -1;
                    break;
                case ConsoleKey.Q:
                    zoom = 1;
                    break;
                default:
                    if (SetMenuEscape(keyPressed)) {
                        return false;
                    }
                    break;
            }
            int terrainType = (int)MapWindowControl.Map.Map[MapWindowControl.WindowWidth / 2 + moveX, MapWindowControl.WindowHeight / 2 - moveY];
            if (terrainType < 5 || (terrainType > 8 && !(_player.Inventory.Contains(_world.GetGameObjectById(8))))) {
                moveX = 0;
                moveY = 0;
            }
            int[] pos = MapWindowControl.Move(moveX, moveY, zoom);
            _player.xPos = pos[0];
            _player.yPos = pos[1];
            _world.GetLocationByCoords(_player.xPos, _player.yPos).Explored = true;
            return true;
        }

        #endregion

        #region Validation
        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString() {
            return Console.ReadLine();
        }

        /// <summary>
        /// Get an integer value from the user bounded by the min and max values
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string key, int minimumValue, int maximumValue, out int integerChoice) {
            integerChoice = -1;
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            if (int.TryParse(key.ToString(), out integerChoice)) {
                if (validateRange) {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue) {
                        return true;
                    }
                } else {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get an unbounded integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string key, out int integerChoice) {
            integerChoice = -1;
            return GetInteger(key, 0, 0, out integerChoice);
        }

        /// <summary>
        /// get a character species value from the user
        /// </summary>
        /// <returns>character species value</returns>
        public Player.SpeciesType GetSpecies() {
            Player.SpeciesType speciesType;
            Enum.TryParse<Player.SpeciesType>(Console.ReadLine(), out speciesType);

            return speciesType;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public bool GetDouble(string prompt, double minimumValue, double maximumValue, out double doubleChoice) {
            bool validResponse = false;
            doubleChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse) {
                if (double.TryParse(Console.ReadLine(), out doubleChoice)) {
                    if (doubleChoice >= minimumValue && doubleChoice <= maximumValue) {
                        validResponse = true;
                    } else {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter a value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                } else {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter a value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        #endregion

        #region Animations------------------------------------------------------------------------------------------
        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplayIntroScreen() {
            bool playing;
            int animationWidth = Animations.GetIntroSize()[0];
            int animationHeight = Animations.GetIntroSize()[1];
            int animationLength = Animations.GetIntroSize()[2];
            int animationLeftOffset = ConsoleLayout.WindowWidth / 2 - animationWidth / 2 + 2; // The +2 is because it's off center and i don't feel like changing every frame
            int animationTopOffset = ConsoleLayout.WindowHeight / 2 - animationHeight / 2;
            int delay = 10;

            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;

            int i = -6; // The -6 is because I added frames to the beginning and don't feel like renumbering everything
            while (i < animationLength + delay) {
                Draw(i, animationHeight, animationLeftOffset, animationTopOffset);
                i += 1;
                System.Threading.Thread.Sleep(64);
            }

            string message = "Press any key to continue or Esc to exit";
            Console.SetCursorPosition(ConsoleLayout.WindowWidth / 2 - message.Length / 2 + 1, ConsoleLayout.WindowHeight * 3 / 4);
            Console.Write(message);
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape) {
                playing = false;
            } else {
                playing = true;
            }

            return playing;
        }

        public void DisplayAnimation() {
            int animationWidth = Animations.GetItemPotionSize()[0];
            int animationHeight = Animations.GetItemPotionSize()[1];
            int animationLength = Animations.GetItemPotionSize()[2];
            int animationLeftOffset = ConsoleLayout.WindowWidth / 2 - animationWidth / 2 + 2; // The +2 is because it's off center and i don't feel like changing every frame
            int animationTopOffset = ConsoleLayout.WindowHeight / 2 - animationHeight / 2;
            int delay = 10;

            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;

            int i = 0; // The -6 is because I added frames to the beginning and don't feel like renumbering everything
            //while (i < animationLength + delay) {
            while (true) {
                Draw(i, animationHeight, animationLeftOffset, animationTopOffset);
                i += 1;
                if (i >= animationLength)
                    i = 0;
                System.Threading.Thread.Sleep(128);
            }

            string message = "Press any key to continue or Esc to exit";
            Console.SetCursorPosition(ConsoleLayout.WindowWidth / 2 - message.Length / 2 + 1, ConsoleLayout.WindowHeight * 3 / 4);
            Console.Write(message);
            keyPressed = Console.ReadKey();
        }

        static void Draw(int i, int height, int leftOffset, int topOffset) {
            string[] lineToDraw = Animations.GetIntro(i);
            for (int y = 0; y < height; y++) {
                Console.SetCursorPosition(leftOffset, topOffset + y);
                Console.WriteLine(lineToDraw[y]);
            }
        }

        #endregion

        #region Inputs--------------------------------------------------------------------------------------
        /// <summary>
        /// Wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey() {
            Console.ReadKey();
        }


        // TODO shorten the list if it already contains the current menu
        public MenuOptions GetMenuChoice(Menu menu, bool back) {
            if (back) {
                MenuOptions temp;
                if (_lastMenuChoice.Count >= 1) {
                    temp = _lastMenuChoice.ElementAt(_lastMenuChoice.Count - 2);
                    _lastMenuChoice.RemoveRange(_lastMenuChoice.Count - 2, 2);
                } else
                    temp = MenuOptions.WorldMap;
                _lastMenuChoice.Add(temp);
                return temp;
            } else
                return GetMenuChoice(menu);
        }

        /// <summary>
        /// Get an action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public MenuOptions GetMenuChoice(Menu menu) {
            
            MenuOptions chosenOption = MenuOptions.None;
            ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
            int keyPressed = -1;
            string toParse = keyPressedInfo.Key.ToString().Substring(keyPressedInfo.Key.ToString().Length - 1);
            if (GetInteger(toParse, 1, menu.MenuChoices.Count, out keyPressed)) {
                chosenOption = menu.MenuChoices[keyPressed];

                if (chosenOption != _lastMenuChoice.ElementAt(0) && chosenOption != MenuOptions.Back)
                        _lastMenuChoice.Add(chosenOption);

            } else {
                //Sub menus
                if (_currentMenuChoice == MenuOptions.Explore) {
                    if (keyPressedInfo.Key == ConsoleKey.Q)
                        chosenOption = MenuOptions.LookAround;
                }
            }

            //Debug(keyPressedInfo.Key.ToString() + ": " + toParse + ": " + keyPressed.ToString() + ": " + chosenOption.ToString());
            string dbug = "";
            foreach (MenuOptions m in _lastMenuChoice) {
                dbug += m.ToString() + ", ";
            }
            //Debug(dbug);

            return chosenOption;
        }

        // TODO use this to replace the jank-ass back button
        public MenuOptions GetMenuEscape(Menu menu) {
            if (_overrideMenu != MenuOptions.None) {
                MenuOptions temp = _overrideMenu;
                _overrideMenu = MenuOptions.None;
                return temp;
            }
            if (_menuEscape > 0 && _menuEscape <= menu.MenuChoices.Count())
                return menu.MenuChoices[_menuEscape];
            else
                return MenuOptions.None;
        }

        public bool SetMenuEscape(ConsoleKey keyPressed) {
            string toParse = keyPressed.ToString().Substring(keyPressed.ToString().Length - 1);
            int key = -1;
            if (GetInteger(toParse, 1, CurrentMenu.MenuChoices.Count, out key)) {
                _menuEscape = key;
                return true;
            } else
                return false;
        }

        #endregion

            /// <summary>
            /// get the player's initial information at the beginning of the game
            /// </summary>
            /// <returns>traveler object with all properties updated</returns>
        public Player GetInitialPlayerInfo() {
            Player player = new Player();

            // Get player's stats
            DisplayGamePlayScreen("Character Creation", "", ActiveMenu.NoMenu);
            Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + 6, ConsoleLayout.MainBoxPositionTop + 4);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Enter your name: ");
            player.Name = GetString();
            DisplayGamePlayScreen("Character Creation", "", ActiveMenu.NoMenu);
            int[] stats = DisplayInteractiveMenuBox(InteractiveMenu.CharacterCreation, player.Name);
            player.Strength = stats[0];
            player.Dexterity = stats[1];
            player.Constitution = stats[2];
            player.Intelligence = stats[3];
            player.Wisdom = stats[4];
            player.Charisma = stats[5];

            return player;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayBattleScreen(Npc npc) {
            DisplayGamePlayScreen("Battle", Text.Battle(npc), ActiveMenu.BattleMenu);
        }

        public void DisplayPlayerInfo() {
            DisplayGamePlayScreen("Player Information", Text.PlayerInfo(_player), ActiveMenu.FullMenu);
        }

        /// <summary>
        /// Display an interactive menu in the main window of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        public void DisplayInventory(List<CollectibleObject> inventory, bool isPlayerInventory) {

            DisplayGamePlayScreen("Inventory", "", ActiveMenu.FullMenu);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Populate inventory menu
            Dictionary<int, CollectibleObject> inventoryToDisplay = new Dictionary<int, CollectibleObject>();
            int key = 0;

            // display menu choices
            int topRow;
            int currentSelection = 1;
            bool dropping = true;

            while (dropping) {

                key = 1;
                inventoryToDisplay.Clear();
                foreach (GameObject gameObject in inventory) {
                    inventoryToDisplay.Add(key, gameObject as CollectibleObject);
                    key++;
                }

                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 45, ConsoleLayout.MainBoxPositionTop + 2);
                if (isPlayerInventory)
                    Console.Write("Press <Q> to drop item");
                else
                    Console.Write("Press <Q> to pick up item");

                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 48, ConsoleLayout.MainBoxPositionTop + 5);
                Console.Write("Item name".PadRight(30) + "Description".PadRight(59) + "Value".PadRight(10));
                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 48, ConsoleLayout.MainBoxPositionTop + 6);
                Console.Write("------------".PadRight(30) + "--------------".PadRight(59) + "--------".PadRight(10));

                topRow = ConsoleLayout.MainBoxPositionTop + 6;
                foreach (KeyValuePair<int, CollectibleObject> item in inventoryToDisplay) {

                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 + 25, ConsoleLayout.MainBoxPositionTop + 2);
                    if (item.Key == currentSelection) {
                        if (item.Value.IsUseable) {
                            if (item.Value.Type == ItemType.Consumable)
                                Console.Write("Press <E> to eat item");
                            if (item.Value.Type == ItemType.Equipment)
                                Console.Write("Press <E> to equip item");
                            if (item.Value.Type == ItemType.Weapon)
                                Console.Write("Press <E> to wield item");
                        } else
                            Console.Write("                                 ");
                    }

                    string indicator = "   ";
                    if (item.Key == currentSelection)
                        indicator = " - ";
                    string formattedMenuChoice = (indicator + item.Value.Name + indicator).PadRight(33) + item.Value.Description.PadRight(60) + item.Value.Value;
                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, topRow += 2);
                    Console.Write($"{formattedMenuChoice}");
                }

                Console.SetCursorPosition(0, 0);


                if (inventoryToDisplay.Count != 0) {
                    Console.BackgroundColor = ConsoleColor.Black;
                    ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                    ConsoleKey keyPressed = keyPressedInfo.Key;
                    switch (keyPressed) {
                        case ConsoleKey.S:
                            if (currentSelection < inventoryToDisplay.Count)
                                currentSelection += 1;
                            break;
                        case ConsoleKey.W:
                            if (currentSelection > 1)
                                currentSelection -= 1;
                            break;
                        case ConsoleKey.Q:
                            Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 10, topRow += 4);
                            if (isPlayerInventory)
                                Console.Write($"Press <Enter> to drop: {inventoryToDisplay[currentSelection].Name}");
                            else
                                Console.Write($"Press <Enter> to pick up: {inventoryToDisplay[currentSelection].Name}");
                            if (Console.ReadKey().Key == ConsoleKey.Enter) {
                                if (isPlayerInventory)
                                    DropObject(inventoryToDisplay[currentSelection]);
                                else
                                    PickUpObject(inventoryToDisplay[currentSelection]);
                                inventoryToDisplay.Remove(currentSelection);
                                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 6 + inventoryToDisplay.Count() * 2);
                                Console.Write(" ".PadRight(100));
                                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 8 + inventoryToDisplay.Count() * 2);
                                Console.Write(" ".PadRight(100));
                                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 10 + inventoryToDisplay.Count() * 2);
                                Console.Write(" ".PadRight(100));
                                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 12 + inventoryToDisplay.Count() * 2);
                                Console.Write(" ".PadRight(100));
                                if (inventoryToDisplay.Count == 0) {
                                    dropping = false;
                                }
                            } else {
                                DisplayGamePlayScreen("Inventory", "", ActiveMenu.FullMenu);
                            }
                            break;
                        case ConsoleKey.E:
                            if (inventoryToDisplay[currentSelection].IsUseable) {
                                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 10, topRow += 4);
                                Console.Write($"Press <Enter> to Use: {inventoryToDisplay[currentSelection].Name}");
                                keyPressedInfo = Console.ReadKey();
                                keyPressed = keyPressedInfo.Key;
                                if (keyPressed == ConsoleKey.Enter) {
                                    if (isPlayerInventory)
                                        UseObject(inventoryToDisplay[currentSelection]);
                                    else {
                                        PickUpObject(inventoryToDisplay[currentSelection]);
                                        UseObject(inventoryToDisplay[currentSelection]);
                                    }
                                    inventoryToDisplay.Remove(currentSelection);
                                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 6 + inventoryToDisplay.Count() * 2);
                                    Console.Write(" ".PadRight(100));
                                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 8 + inventoryToDisplay.Count() * 2);
                                    Console.Write(" ".PadRight(100));
                                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 10 + inventoryToDisplay.Count() * 2);
                                    Console.Write(" ".PadRight(100));
                                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 50, ConsoleLayout.MainBoxPositionTop + 12 + inventoryToDisplay.Count() * 2);
                                    Console.Write(" ".PadRight(100));
                                    if (inventoryToDisplay.Count == 0) {
                                        dropping = false;
                                    } else {
                                        DisplayGamePlayScreen("Inventory", "", ActiveMenu.FullMenu);
                                    }
                                } else {
                                    DisplayGamePlayScreen("Inventory", "", ActiveMenu.FullMenu);
                                }
                            }
                            break;
                        default:
                            if (SetMenuEscape(keyPressed))
                                return;
                            break;
                    }
                }

                if (inventoryToDisplay.Count == 0) {
                    dropping = false;
                    DisplayGamePlayScreen("Inventory", "", ActiveMenu.FullMenu);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.WindowBorderSide, ConsoleLayout.MainBoxPositionTop + 12);
                    if (isPlayerInventory)
                        Console.Write(ConsoleWindowHelper.Center("Your inventory is empty", ConsoleLayout.MainBoxWidth - 4));
                    else
                        Console.Write(ConsoleWindowHelper.Center("There is nothing here", ConsoleLayout.MainBoxWidth - 4));
                }
            }
        }
        public void DisplaySettings() {
            DisplayGamePlayScreen("Settings", Text.GameSettings(), ActiveMenu.SettingsMenu);
        }
   
        public void DisplayDevMenu() {
            DisplayGamePlayScreen("Developer's Menu", "", ActiveMenu.DevMenu);
        }

        public void DisplayClosingScreen() {
            DisplayGamePlayScreen("Goodbye", "", ActiveMenu.NoMenu);
            Console.ReadKey();
        }

        public void DisplayCurrentLocationInfo() {

            Location currentLocation = _world.GetLocationByCoords(_player.xPos, _player.yPos);

            DisplayGamePlayScreen("Location Information", Text.CurrentLocationInfo(currentLocation), ActiveMenu.FullMenu);
            _player.Experience += currentLocation.ExperiencePoints;
            currentLocation.ExperiencePoints = 0;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 45, ConsoleLayout.MainBoxPositionTop + 2);
            if (_world.GetGameObjectsByLocation(_player.xPos,_player.yPos).Count == 0) {
                Console.Write("There are no items here");
            } else {
                Console.Write("Press <Q> to look at items");
            }
        }

        // TODO this probably doesn't work.  Fix it.
        public int DisplayGetGameObjectToLookAt() {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            // Get a list of game objects in the current location
            List<GameObject> gameObjectsInLocation = _world.GetGameObjectsByLocation(_player.xPos, _player.yPos);

            if (gameObjectsInLocation.Count > 0) {
                DisplayGamePlayScreen("Look at an object", Text.ListGameObjects(gameObjectsInLocation), ActiveMenu.FullMenu);

                while (!validGameObjectId) {
                    // Get an integer from the player
                    GetInteger($"Enter the ID of the object you wish to look at:", out gameObjectId);

                    // Validate int as a valid game object id and in current location
                    if (_world.IsValidGameObjectByLocationCoord(gameObjectId, _player.xPos, _player.yPos)) {
                        validGameObjectId = true;
                    } else {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id.  Please try again.");
                    }
                }
            } else {
                DisplayGamePlayScreen("Look at an object", "It appears there are no game objects here.", ActiveMenu.FullMenu);
            }
            return gameObjectId;
        }

        public void DisplayListOfAllGameObjects() {
            DisplayGamePlayScreen("List: Items", Text.ListGameObjects(_world.GameObjects), ActiveMenu.DevMenu);
        }
        public void DisplayListOfAllLocations() {
            DisplayGamePlayScreen("List: Locations", Text.ListAllLocations(_world.Locations), ActiveMenu.DevMenu);
        }
        public void DisplayListOfAllNpcs() {
            DisplayGamePlayScreen("List: Npcs", Text.ListAllNpcs(_world.Npcs,_player), ActiveMenu.DevMenu);
        }

        public void DisplayLookAt() {
            // Display a list of objects in a location and get a player choice
            int gameObjectToLookAtId = DisplayGetGameObjectToLookAt();

            // Display game object info
            if (gameObjectToLookAtId != 0) {
                // Get the game object from the world
                GameObject gameObject = _world.GetGameObjectById(gameObjectToLookAtId);

                // Display information for the object chosen
                DisplayGamePlayScreen(gameObject.Name, Text.LookAt(gameObject), ActiveMenu.FullMenu);
            }
        }

        public void DisplayLookAround() {

            // Get a list of game objects in the current location
            List<GameObject> gameObjectsInLocation = _world.GetGameObjectsByLocation(_player.xPos, _player.yPos);
            List<CollectibleObject> CollectibleObjectsInLocation = new List<CollectibleObject>();
            // Remove nonCollectible items
            foreach (GameObject item in gameObjectsInLocation) {
                if (item is CollectibleObject) {
                    CollectibleObjectsInLocation.Add(item as CollectibleObject);
                }
            }

            if (gameObjectsInLocation.Count > 0) {
                DisplayInventory(CollectibleObjectsInLocation, false);
//                DisplayGamePlayScreen("Look at an object", Text.ListGameObjects(gameObjectsInLocation), ActiveMenu.FullMenu);
            }
        }

        #endregion

        #endregion

        #region Debug

        public void Debug() {
            Debug(debug);
        }

        public void Debug(string txt) {
            debug = txt;
            ConsoleColor prevF = Console.ForegroundColor;
            ConsoleColor prevB = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.Write(txt);
            Console.ForegroundColor = prevF;
            Console.BackgroundColor = prevB;

        }
        #endregion
    }
}
