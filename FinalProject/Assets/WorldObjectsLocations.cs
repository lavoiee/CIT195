using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// A partial class to hold all location objects in the game world
    /// </summary>
    public static partial class WorldObjects {
        public static IEnumerable<Location> Locations = new List<Location>()
        {
            new Location
            {
                CommonName = "Burnt-out house",
                xCoord = 1300,
                yCoord = 850,
                Description = "The remains of your childhood home.\n",
                Accessable = true,
                ExperiencePoints = 0
            },
            new Location
            {
                CommonName = "General Store",
                xCoord = 1301,
                yCoord = 850,
                Description = "They haven't let you inside in years.\n",
                Accessable = true,
                ExperiencePoints = 10
            },
            new Location
            {
                CommonName = "Blacksmith",
                xCoord = 1299,
                yCoord = 850,
                Description = "Better stay away.  Dave will come after me with the hammer again.\n",
                Accessable = true,
                ExperiencePoints = 15
            },
            new Location
            {
                CommonName = "Bakery",
                xCoord = 1300,
                yCoord = 851,
                Description = "He had a nice dog.\n",
                Accessable = true,
                ExperiencePoints = 20
            },
            new Location
            {
                CommonName = "Bob's house",
                xCoord = 1300,
                yCoord = 849,
                Description = "This village is really crowded.\n",
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "Forest Entrance", // Village side
                xCoord = 1370,
                yCoord = 850,
                Description = "People don't usually come back...",
                Accessable = true,
                ExperiencePoints = 100
            },

            new Location
            {
                CommonName = "Mill",
                xCoord = 1338,
                yCoord = 813,
                Description = "This is where father used to work",
                Accessable = true,
                ExperiencePoints = 1000
            }
        };
    }
}
