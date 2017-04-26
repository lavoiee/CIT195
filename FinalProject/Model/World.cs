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
        private List<GameObject> _gameObjects;
        System.Random prng = new Random(MapWindowControl.seed);


        public List<Location> Locations {
            get { return _locations; }
            set { _locations = value; }
        }

        public List<GameObject> GameObjects {
            get { return _gameObjects; }
            set { _gameObjects = value; }
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
            _gameObjects = WorldObjects.Objects as List<GameObject>;
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

            // run through the location list and grab the correct one
            foreach (Location loc in _locations) {
                if (loc.xCoord == xCoord) {
                    if (loc.yCoord == yCoord)
                        location = loc;
                }
            }

            // Nothing has been designed for this location.  Create a random location object
            if (location == null) {
                location = GenerateRandomLocation(xCoord, yCoord);
            }
            return location;
        }

        Location GenerateRandomLocation(int x, int y) {
            int random = prng.Next();
            int height = MapWindowControl.GetHeightAtPosition();
            string[] randomLocation = Text.GetRandomLocation(height);
            Location location = new Location {
                CommonName = randomLocation[0],
                xCoord = x,
                yCoord = y,
                Description = randomLocation[1],
                Accessable = true,
                ExperiencePoints = 0,
                Generic = true
            };
            Locations.Add(location);
            return location;
        }

        //
        // 
        //
        public bool IsValidGameObjectByLocationCoord(int gameObjectId, int xPos, int yPos) {
            List<int> gameObjectIds = new List<int>();

            // create a list of game object IDs in given location
            foreach (GameObject gameObject in _gameObjects) {
                if (gameObject.yPos == yPos)
                    if (gameObject.xPos == xPos)
                        gameObjectIds.Add(gameObject.ID);
            }

            // Return whether the object exists at the location
            if (gameObjectIds.Contains(gameObjectId))
                return true;
            else
                return false;
        }


        public List<GameObject> GetGameObjectsByLocation(int xPos, int yPos) {
            List<GameObject> gameObjects = new List<GameObject>();

            // Iterate through the game object list and grab all that are in the current location
            foreach (GameObject gameObject in _gameObjects) {
                if (gameObject.yPos == yPos)
                    if (gameObject.xPos == xPos) {
                        if (gameObject is CollectibleObject) {
                            CollectibleObject item = gameObject as CollectibleObject;
                            if (item.Owner == null)
                                gameObjects.Add(gameObject);
                        } else
                            gameObjects.Add(gameObject);
                    }
            }
            return gameObjects;
        }

        public bool IsValidCollectableObjectByLocationCoord(int gameObjectId, int xPos, int yPos) {
            List<int> collectableObjectIds = new List<int>();

            // create a list of game object IDs in given location
            foreach (GameObject gameObject in _gameObjects) {
                if (gameObject is CollectibleObject)
                    if (gameObject.yPos == yPos)
                        if (gameObject.xPos == xPos)
                            collectableObjectIds.Add(gameObject.ID);
            }

            // Return whether the object exists at the location
            if (collectableObjectIds.Contains(gameObjectId))
                return true;
            else
                return false;
        }

        public List<CollectibleObject> GetCollectableObjectsByLocation(int xPos, int yPos) {
            List<CollectibleObject> collectableObjects = new List<CollectibleObject>();

            // Iterate through the game object list and grab all that are in the current location
            foreach (GameObject gameObject in _gameObjects) {
                if (gameObject is CollectibleObject)
                    if (gameObject.yPos == yPos)
                        if (gameObject.xPos == xPos) {
                            collectableObjects.Add(gameObject as CollectibleObject);
                        }
            }
            return collectableObjects;
        }

        public GameObject GetGameObjectById(int id) {
            GameObject gameObjectToReturn = null;

            // Run through the game object list and grab the correct one
            foreach (GameObject gameObject in _gameObjects) {
                if (gameObject.ID == id) {
                    gameObjectToReturn = gameObject;
                }
            }

            // Throw an exception if the object doesn't exist
            if (gameObjectToReturn == null) {
                string feedbackMessage = $"The Game Object ID {id} does not exist in the current world.";
                throw new ArgumentException(id.ToString(), feedbackMessage);
            }

            return gameObjectToReturn;
        }

        #endregion
    }
}
