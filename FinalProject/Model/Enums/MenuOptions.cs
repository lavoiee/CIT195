using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum MenuOptions {
        None,

        // Main Menu
        Character,
        Inventory,
        WorldMap,
        Explore,
        Settings,
        Exit,

        // Settings
        Back,
        DevMenu,

        // Developer Actions
        ListLocations,
        ListObjects,
        ListNpcs,

        // Player actions
        LookAround,
        LookAt,
        PickUp,
        PutDown
    }
}
