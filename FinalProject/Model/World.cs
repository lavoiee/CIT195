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

        public bool IsValidLocationID(int locationID) {
            List<int> locationIDs = new List<int>();

            //
            // create a list of location ids
            //
            foreach (Location loc in _locations) {
                locationIDs.Add(loc.LocationID);
            }

            //
            // determine if the location id is a valid id and return the result
            //
            if (locationIDs.Contains(locationID)) {
                return true;
            } else {
                return false;
            }
        }


        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int locationID) {
            Location location = GetLocationByID(locationID);
            if (location.Accessable == true) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// return the next available ID for a Location object
        /// </summary>
        /// <returns>next LocationObjectID </returns>
        public int GetMaxLocationId() {
            int MaxId = 0;

            foreach (Location location in Locations) {
                if (location.LocationID > MaxId) {
                    MaxId = location.LocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a Location object using an ID
        /// </summary>
        /// <param name="ID">location ID</param>
        /// <returns>requested location</returns>
        public Location GetLocationByID(int ID) {
            Location location = null;

            //
            // run through the location list and grab the correct one
            //
            foreach (Location loc in _locations) {
                if (loc.LocationID == ID) {
                    location = loc;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (location == null) {
                string feedbackMessage = $"The Location ID {ID} does not exist in the current world.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return location;
        }

        #endregion
    }
}
