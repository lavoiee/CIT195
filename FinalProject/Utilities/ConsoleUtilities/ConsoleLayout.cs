using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// static class sets the layout of the game screen
    /// </summary>
    public static class ConsoleLayout {
        //
        // console window configuration
        //
        public static int WindowWidth = 160;
        public static int WindowHeight = 50;
        public static int WindowVerticalSplit = 120;//  |
        public static int WindowHorizontalSplit = 48;//  -
        public static int WindowPositionLeft = 0;
        public static int WindowPositionTop = 0;
        public static int WindowBorderSide = 3;

        //
        // Header configuration
        //
        // Note: The header height is the sum of lines of text and 2 blank lines.
        //       The top positions of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the header should not change.
        public static int HeaderWidth = WindowWidth - WindowBorderSide;
        public static int HeaderPositionLeft = WindowBorderSide;
        public static int HeaderPositionTop = 1;

        //
        // Menu bar configuration
        //
        public static int MenuBarPositionTop = 4;
        public static int MenuBarWidth = WindowWidth - 4;
        public static int MenuBarPositionLeft = WindowBorderSide - 1;

        //
        // Main box configuration
        //
        public static int MainBoxPositionTop = MenuBarPositionTop + 1;
        public static int MainBoxPositionLeft = WindowBorderSide + 1; // 1 for the box border
        public static int MainBoxWidth = WindowVerticalSplit - WindowBorderSide -1; // 
        public static int MainBoxHeight = WindowHorizontalSplit - MainBoxPositionTop + 1;

        //
        // Side box configuration
        //
        public static int SideWindowPositionTop = MenuBarPositionTop +1;
        public static int SideWindowWidth = WindowWidth - WindowVerticalSplit -1 ;
        public static int SideWindowHeight = WindowHorizontalSplit - SideWindowPositionTop + 1;
        public static int SideWindowPositionLeft = WindowVerticalSplit;

        //
        // input box configuration
        //
        public static int InputBoxWidth = WindowWidth - WindowBorderSide * 2 + 1;
        public static int InputBoxHeight = WindowHeight - WindowHorizontalSplit - 3; // 4 for the footer height, 1 for offset
        public static int InputBoxPositionLeft = WindowBorderSide + 1;
        public static int InputBoxPositionTop = WindowHorizontalSplit + 1;

        //
        // Footer configuration
        //
        // Note: The footer height is the sum of lines of text and 2 blank lines.
        //       The heights of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the footer should not change.
        public static int FooterWidth = WindowWidth - WindowBorderSide;
        public static int FooterPositionLeft = WindowBorderSide;
        public static int FooterPositionTop = WindowHeight - 2; // 3 for the height of the footer, 1 for the window border

        public static void ToggleVerticalSplit(bool toggle) {
            if (!toggle)
                WindowVerticalSplit = WindowWidth - WindowBorderSide;
        }

        public static void ToggleVerticalSplit(int size) {
            WindowVerticalSplit = size;
        }

        public static void ToggleHorizontalSplit(bool toggle) {
            if (!toggle)
                WindowHorizontalSplit = WindowWidth - WindowBorderSide;
        }

        public static void ToggleHorizontalSplit(int size) {
            WindowHorizontalSplit = size;
        }

    }
}
