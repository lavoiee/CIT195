using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// Static class to hold all objects in the game world; locations, game objects, npc's
    /// </summary>
    public static class WorldObjects {
        public static IEnumerable<Location> Locations = new List<Location>()
        {
            new Location
            {
                CommonName = "Burnt-out house",
                LocationID = 1,
                Description = "The shell of your childhood home.\n",
                Accessable = true,
                ExperiencePoints = 0
            },

            new Location
            {
                CommonName = "Forest Entrance", // Village side
                LocationID = 2,
                Description = "The entrance to a forest",
                Accessable = true,
                ExperiencePoints = 10
            }
        };
    }
}
