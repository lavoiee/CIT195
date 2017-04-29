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
            MenuChoices = new Dictionary<int, MenuOptions>() {
                { 0, MenuOptions.None }
            }
        };

        // TODO do something with the menu names and titles or get rid of them
        public static Menu FullMenu = new Menu() {
            MenuName = "",
            MenuTitle = "Information",
            MenuChoices = new Dictionary<int, MenuOptions>() {
                { 1, MenuOptions.WorldMap },
                { 2, MenuOptions.Explore },
                { 3, MenuOptions.Character },
                { 4, MenuOptions.Inventory },
                { 5, MenuOptions.Settings }
            }
        };

        public static Menu ActionMenu = new Menu() {
            MenuName = "",
            MenuTitle = "Actions",
            MenuChoices = new Dictionary<int, MenuOptions>() {
                { 1, MenuOptions.Back },
                { 2, MenuOptions.LookAround },
                { 3, MenuOptions.LookAt },
                { 4, MenuOptions.PickUp },
                { 5, MenuOptions.PutDown }
            }
        };

        public static Menu SettingsMenu = new Menu() {
            MenuName = "",
            MenuTitle = "Settings",
            MenuChoices = new Dictionary<int, MenuOptions>() {
                { 1, MenuOptions.Back },
                { 2, MenuOptions.DevMenu }
            }
        };

        public static Menu DevMenu = new Menu() {
            MenuName = "",
            MenuTitle = "Settings",
            MenuChoices = new Dictionary<int, MenuOptions>() {
                { 1, MenuOptions.Back },
                { 2, MenuOptions.ListLocations },
                { 3, MenuOptions.ListObjects },
                { 4, MenuOptions.ListNpcs }
            }
        };

        public static Menu BattleMenu = new Menu() {
            MenuName = "",
            MenuTitle = "FIGHT!",
            MenuChoices = new Dictionary<int, MenuOptions>() {
                { 1, MenuOptions.WorldMap },
                { 2, MenuOptions.Explore },
                { 3, MenuOptions.Character },
                { 4, MenuOptions.Inventory },
                { 5, MenuOptions.Settings }
            }
        };
    }
}