using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// class hold information about each menu
    /// </summary>
    public class Menu {
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public Dictionary<char, MenuOptions> MenuChoices { get; set; }

        public Dictionary<int, string> InteractiveMenuChoices { get; set; }
    }
}
