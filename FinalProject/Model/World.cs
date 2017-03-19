using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// class of the game map
    /// </summary>
    public class World {
        #region ***** define all lists to be maintained by the World object *****

        //
        // list of all locations
        //
        private List<Location> _locations;

        public List<Location> Locations {
            get { return _locations; }
            set { _locations = value; }
        }

        #endregion

        #region ***** constructor *****

        //
        // default world constructor
        //
        public World() {
            //
            // add all of the world objects to the game
            // 
            IntializeWorld();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the world with all of the locations
        /// </summary>
        private void IntializeWorld() {
            _locations = WorldObjects.Locations as List<Location>;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int xCoord, int yCoord) {
            Location location = GetLocationByCoords(xCoord,yCoord);
            if (location.Accessable == true) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// get a Location object using an ID
        /// </summary>
        /// <param name="ID">location ID</param>
        /// <returns>requested location</returns>
        public Location GetLocationByCoords(int xCoord, int yCoord) {
            Location location = null;

            //
            // run through the location list and grab the correct one
            //
            foreach (Location loc in _locations) {
                if (loc.xCoord == xCoord) {
                    if (loc.yCoord == yCoord)
                        location = loc;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (location == null) {
                string feedbackMessage = $"The Location: ({xCoord},{yCoord}) does not exist in the current world.";
                location = new Location {
                    CommonName = "Unexplored",
                    xCoord = xCoord,
                    yCoord = yCoord,
                    Description = "Looks like the programmer hasn't gotten this far",
                    Accessable = true,
                    ExperiencePoints = 0
                };
                //throw new ArgumentException($"({xCoord},{yCoord})", feedbackMessage);
            }

            return location;
        }


        #endregion
    }
}
