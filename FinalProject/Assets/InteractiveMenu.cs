using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    class InteractiveMenu {

        /// <summary>
        /// static class to hold key/value pairs for menu options
        /// </summary>
        public static Dictionary<int, string> MenuItems = new Dictionary<int, string> {
        };
        public static Menu CharacterCreation = new Menu() {

            // TODO do something with the menu names and titles

            MenuName = "Character Creation",
            MenuTitle = "I'm in the interactiveMenu class, fix me",
            InteractiveMenuChoices = new Dictionary<int, string>() {
                { 1, "Strength" },
                { 2, "Dexterity" },
                { 3, "Constitution" },
                { 4, "Intelligence" },
                { 5, "Wisdom" },
                { 6, "Charisma" }
            }
        };

        public static Menu Inventory = new Menu() {
            MenuName = "Inventory",
            MenuTitle = "I'm in the interactiveMenu class, fix me",
            InteractiveMenuChoices = new Dictionary<int, string>() {

            }
        };
    }
}