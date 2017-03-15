using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActiveMenu {
        public static Menu NoMenu = new Menu() {
            MenuName = "|  Menu  |",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, MenuOptions>() {
                { ' ', MenuOptions.None }
            }
        };

        public static Menu FullMenu = new Menu() {
            MenuName = "Shitfuck",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, MenuOptions>() {
                { '1', MenuOptions.WorldMap },
                { '2', MenuOptions.LocalMap },
                { '3', MenuOptions.Character },
                { '4', MenuOptions.Inventory },
                { '5', MenuOptions.Settings }
            }
        };
    }
}