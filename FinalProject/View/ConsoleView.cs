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

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, World gameWorld) {
            _player = gamePlayer;
            _world = gameWorld;

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
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt) {
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

            foreach (KeyValuePair<char, MenuOptions> menuChoice in menu.MenuChoices) {
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
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.SideWindowPositionLeft + 2, ConsoleLayout.SideWindowPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.SideWindowWidth - 4));

            //
            // Display side window choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.SideWindowPositionTop + 3;
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

            int startingRow = ConsoleLayout.MainBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines) {
                Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + 2, row);
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


            Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - (heading.Length + 8) / 2, ConsoleLayout.MainBoxPositionTop + 6);
            Console.Write(@"-=  " + heading + @"  =-");


            while (!complete) {
                topRow = ConsoleLayout.MainBoxPositionTop + 9;
                foreach (KeyValuePair<int, string> menuChoice in menu.InteractiveMenuChoices) {
                    string indicator = "   ";
                    if (menuChoice.Key == currentSelection)
                        indicator = " - ";
                    string formatedMenuChoice = indicator + ConsoleWindowHelper.ToLabelFormat(menuChoice.Value) + indicator;
                    Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + ConsoleLayout.MainBoxWidth / 2 - 19, topRow += 2);
                    Console.Write($"{formatedMenuChoice}".PadRight(30) + $"< {info[menuChoice.Key - 1]} > ");
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

        #region Map drawing

        public void InitializeMap() {
            MapWindowControl.InitializeMaps();
        }

        public void DisplayWorldMap() {
            DisplayWorldMap(false);
        }

        public void DisplayWorldMap(bool zooming) {
            bool drawing = true;
            DisplayGamePlayScreen("World Map", "", ActiveMenu.FullMenu, "");
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
                drawing = MovePlayer();
                MapWindowControl.DrawScreen();
                // Draw Player
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(MapWindowControl.WindowLeft + MapWindowControl.WindowWidth/2, MapWindowControl.WindowTop + MapWindowControl.WindowHeight/2);
                Console.Write("ጰ");
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public bool MovePlayer() {
            ConsoleKeyInfo response = Console.ReadKey();

            int moveX = 0;
            int moveY = 0;
            int zoom = 0;

            //if (response.KeyChar == '1') return false;
            if (response.KeyChar == '2') return false;
            if (response.KeyChar == '3') return false;
            if (response.KeyChar == '4') return false;
            if (response.KeyChar == '5') return false;
            if (response.Key == ConsoleKey.A) moveX = -_player.MoveSpeed;
            if (response.Key == ConsoleKey.D) moveX = _player.MoveSpeed;
            if (response.Key == ConsoleKey.W) moveY = _player.MoveSpeed;
            if (response.Key == ConsoleKey.S) moveY = -_player.MoveSpeed;
            if (response.Key == ConsoleKey.E) zoom = -1;
            if (response.Key == ConsoleKey.Q) zoom = 1;

            int terrainType = (int)MapWindowControl.Map.Map[MapWindowControl.WindowWidth / 2 + moveX, MapWindowControl.WindowHeight / 2 - moveY];
            if (terrainType < 5 || terrainType > 8) {
                moveX = 0;
                moveY = 0;
            }
                int[] pos = MapWindowControl.Move(moveX, moveY, zoom);
                _player.PosX = pos[0];
                _player.PosY = pos[1];

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
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice) {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse) {
                if (int.TryParse(Console.ReadLine(), out integerChoice)) {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue) {
                        validResponse = true;
                    } else {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                } else {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
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

        #region Animations
        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplayIntroScreen() {
            bool playing = true;
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

        #region Inputs
        /// <summary>
        /// Wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey() {
            Console.ReadKey();
        }

        /// <summary>
        /// Get an action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public MenuOptions GetMenuChoice(Menu menu) {
             MenuOptions chosenOption = MenuOptions.None;

            //
            // TODO validate menu choices
            //
            ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
            char keyPressed = keyPressedInfo.KeyChar;
            chosenOption = menu.MenuChoices[keyPressed];

            return chosenOption;
        }
        #endregion

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>traveler object with all properties updated</returns>
        public Player GetInitialPlayerInfo() {
            Player player = new Player();

            //
            // get traveler's name
            //
            /*DisplayGamePlayScreen("Character Creation - Name", Text.InitializeMissionGetPlayerName(), ActionMenu.CharacterCreation, "");
            DisplayInputBoxPrompt("Enter your name: ");
            player.Name = GetString();
            */
            // 
            // Get player's stats
            //
            DisplayGamePlayScreen("Character Creation", "", ActiveMenu.NoMenu, "");
            Console.SetCursorPosition(ConsoleLayout.MainBoxPositionLeft + 2, ConsoleLayout.MainBoxPositionTop + 3);
            Console.Write("Enter your name: ");
            player.Name = GetString();
            DisplayGamePlayScreen("Character Creation", "", ActiveMenu.NoMenu, "");
            int[] stats = DisplayInteractiveMenuBox(InteractiveMenu.CharacterCreation, player.Name);
            player.Strength = stats[0];
            player.Dexterity = stats[1];
            player.Constitution = stats[2];
            player.Intelligence = stats[3];
            player.Wisdom = stats[4];
            player.Charisma = stats[5];

            //
            // echo the traveler's info
            //
            //DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoPlayerInfo(player), ActiveMenu.NoMenu, "");
            //GetContinueKey();

            return player;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayTravelerInfo() {
            DisplayGamePlayScreen("Player Information", Text.PlayerInfo(_player), ActiveMenu.FullMenu, "");
        }

        public void DisplayInventory() {
            DisplayGamePlayScreen("Player Inventory", Text.PlayerInventory(), ActiveMenu.FullMenu, "");
        }

        public void DisplayClosingScreen() {
            DisplayGamePlayScreen("Goodbye", "", ActiveMenu.NoMenu, "");
            Console.ReadKey();
        }

        public void DisplayCurrentLocationInfo() {

            Location currentLocation = _world.GetLocationByCoords(_player.PosX, _player.PosY);

            DisplayGamePlayScreen("Location Information", Text.CurrentLocationInfo(currentLocation), ActiveMenu.FullMenu, "");
            _player.Experience += currentLocation.ExperiencePoints;
        }

        #endregion

        #endregion
    }
}
