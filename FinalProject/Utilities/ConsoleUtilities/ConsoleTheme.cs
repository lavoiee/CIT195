using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// static class to manage the console game theme
    /// </summary>
    public static class ConsoleTheme {
        //
        // splash screen colors
        //
        public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.Gray;

        //
        // main console window colors
        //
        public static ConsoleColor WindowBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor WindowForegroundColor = ConsoleColor.White;

        //
        // console window header colors
        //
        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.White;

        //
        // console window footer colors
        //
        public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkGray;
        public static ConsoleColor FooterForegroundColor = ConsoleColor.White;

        //
        // menu box colors
        //
        public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MenuForegroundColor = ConsoleColor.White;
        public static ConsoleColor MenuSelectionBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MenuSelectionForegroundColor = ConsoleColor.White;
        public static ConsoleColor MenuBorderColor = ConsoleColor.Gray;

        //
        // message box colors
        //
        public static ConsoleColor MainBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MainBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor MainBoxBorderColor = ConsoleColor.Gray;
        public static ConsoleColor MainBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MainBoxHeaderForegroundColor = ConsoleColor.White;

        //
        // input box colors
        //
        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.White;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.Gray;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.White;
    }
}
