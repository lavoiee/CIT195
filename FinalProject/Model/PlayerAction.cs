using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUpItem,
        PickUpTreasure,
        PutDownItem,
        PutDownTreasure,
        Travel,
        TravelerInfo,
        TravelerInventory,
        TravelerTreasure,
        ListTARDISDestinations,
        ListItems,
        ListTreasures,
        Exit
    }
}
