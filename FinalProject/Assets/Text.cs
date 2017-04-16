using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text {
        public static List<string> HeaderText = new List<string>() { "The Necromancer" };
        public static List<string> FooterText = new List<string>() { "Lichty, CIT195" };

        // Biomes
        public static List<string> BiomeOcean;
        public static List<string> BiomeShallows;
        public static List<string> BiomeLowlands;
        public static List<string> BiomePlains;
        public static List<string> BiomeForest;
        public static List<string> BiomeHighlands;
        public static List<string> BiomeMountain;
        public static List<string> BiomePeaks;

        #region INTITIAL GAME SETUP

        /*

            One of my friends read the intro story here and gave me the 'are you ok?' look, so I suppose I should explain the intent.  
            I plan on porting this game over to unity this summer and expanding on it.  I'm trying to get an idea of how I want the overall story arc to go.

            I like the 'morality in the mechanics' concept rather than the evil/good meter in most games.
            The goal is to have a simulated world in the game without any clearly defined story.
            Villagers will perform basic tasks to keep themselves fed, sheltered, defended, and happy.
            I want to add in some personality traits to add a little chaos and realism, but that might be a little far reaching.

            Anyway, the main character is a paranoid teenager with a skewed idea of what is happening around him.  The game will start out with paranoia and 
            misperceptions all around.  The player will see through the paranoia and defeat the necromancer orchestrating the whole thing, or become the necromancer
            he is accused of being.

            I want the feel of village life to be wholesome and pleasant, and the necromancy side to be extremely dark and disturbing.  This is more immersive
            than an alignment variable and a cosmetic change on the character.

        */
        public static string IntroductionP1() {
            string messageBoxText =
                "You live in a small village with your father.  The townsfolk say your mother died in childbirth, but then \n" +
                "  they also say your parents were once heros and powerful sorcerors.  They'll say anything.  Their pity \n" +
                "  stings more than any blow your father could ever manage to land.  They can't be trusted, but you know \n" +
                "  the truth.  Your mother was probably just another whore and your father has never anything more than a \n" +
                "  worthless drunk.";

            return messageBoxText;
        }

        public static string IntroductionP2() {
            string messageBoxText =
                "Something feels different as you shake the rain from your cloak in the entryway of your run down house.\n" +
                "  In the light of the open door, you notice muddy footprints amidst the flith covering the floor.  There is \n" +
                "  a sickening retch from the other room.  You relax.  Maybe father will pass out early tonight.  You enter \n" +
                "  the room to see his familiar frame sprawled out next to an array of empty bottles.  One, still half \n" +
                "  empty, rests in the center of the floor's newest stain.  Another retching gasp drowns out your father's \n" +
                "  snores.  You spin just in time to see the disemboweled dog lunge at your face.  A chain leaps and the dog \n" +
                "  jerks to a stop.  The momentum of the animal's sagging organs carries their gore over your rain soaked \n" +
                "  cloak.  It lets out a gurgling growl and strains against the chain.  This was the baker's dog!  How is \n" +
                "  this creature alive?  Something in the fringes of your vision draws your attention.  Just outside the \n" +
                "  ring of gore soaking through the floorboards, lies a book. The book is composed of uncropped parchment, \n" +
                "  casually bound in black leather.  Despite the low light, faint, iridescent lines wander the cover.  The \n" +
                "  feral intensity of the beast's gnashing jaws is dulled by the call of the book. \n" + "\n " +
                "  You pick it up an begin to read...";

            return messageBoxText;
        }

        public static string SpellSelection() {
            string messageText = "Spell Selection";
            return messageText;
        }

        public static string IntroductionP3() {

            string messageBoxText =
                "The pain blossoming from your back breaks you free from the book's grasp.  Dazed, you recognize the baker's \n" +
                "  voice as he slams a mallet against the base of your skull.  You slump to the ground.  You're dimly aware \n" +
                "  of other voices in the room, the smell of torches, the sound of tearing wood.  The dog is free.  It tears \n" +
                "  the throat from its former master.  The other voices panic as the undead animal shrugs off their blows. \n" +
                "  Father grunts in his fitful sleep.  A man swings his torch at the animal.  The scent of burning hair fills \n" +
                "  the room.  Father screams.  You drag yourself out the back door as the walls begin to blister.";
            return messageBoxText;
        }

        public static string CurrentLocationInfo(Location location) {
            string messageBoxText =
                $"Current Location({location.xCoord},{location.yCoord}): {location.CommonName} \n \n \t {location.Description} \n \n \n \t \t \t Experience gained: {location.ExperiencePoints}";

            return messageBoxText;
        }

        #region Initialize Mission Text
        public static string InitializeMissionGetPlayerName() {
            string messageBoxText =
                "Enter your name.";

            return messageBoxText;
        }


        public static string InitializeMissionEchoPlayerInfo(Player player) {
            string messageBoxText =
                $"Very good then {player.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your mission. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tName: {player.Name}\n" +
                $"\tStrength: {player.Strength}\n" +
                $"\tDexterity: {player.Dexterity}\n" +
                $"\tConstitution: {player.Constitution}\n" +
                $"\tIntelligence: {player.Intelligence}\n" +
                $"\tWisdom: {player.Wisdom}\n" +
                $"\tCharisma: {player.Charisma}\n" +
                " \n" +
                "Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string PlayerInfo(Player player) {
            string messageBoxText =
                $"\tName: {player.Name}\n" +
                $"\tStrength: {player.Strength}\n" +
                $"\tDexterity: {player.Dexterity}\n" +
                $"\tConstitution: {player.Constitution}\n" +
                $"\tIntelligence: {player.Intelligence}\n" +
                $"\tWisdom: {player.Wisdom}\n" +
                $"\tCharisma: {player.Charisma}\n" +
                $"\tExperience: {player.Experience}\n" +
                " \n";

            return messageBoxText;
        }


        // TODO tie in objects
        public static string PlayerInventory() {
            string messageBoxText = "You don't have any items.";

            return messageBoxText;
        }

        // TODO unfuck the settings menu, the choices should be in the window, not the top bar.  Make it interactive.
        public static string GameSettings() {
            string messageBoxText = "This is where the settings will go.";

            return messageBoxText;
        }

        //public static string Travel(int currentSpaceTimeLocationId, List<SpaceTimeLocation> spaceTimeLocations)
        //{
        //    string messageBoxText =
        //        $"{gameTraveler.Name}, Aion Base will need to know the name of the new location.\n" +
        //        " \n" +
        //        "Enter the ID number of your desired location from the table below.\n" +
        //        " \n";


        //    string spaceTimeLocationList = null;

        //    foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
        //    {
        //        if (race != Character.RaceType.None)
        //        {
        //            raceList += $"\t{race}\n";
        //        }
        //    }

        //    messageBoxText += raceList;

        //    return messageBoxText;
        //}

        #endregion

        #region PLAYER ACTIONS

        public static string LookAt(GameObject gameObject) {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name} \n" + "\n" +
                gameObject.Description + "\n" + "\n";

            if (gameObject is CollectibleObject) {
                CollectibleObject collectibleObject = gameObject as CollectibleObject;

                messageBoxText += $"The {collectibleObject.Name} has a value of {collectibleObject.Value} and ";

                if (collectibleObject.CanPickup) {
                    messageBoxText += "can be picked up";
                } else {
                    messageBoxText += "can't be picked up";
                }
            } else {
                messageBoxText += $"The {gameObject.Name} can't not be picked up";
            }
            return messageBoxText;
        }

        #endregion

        #region RANDOM LOCATION GENERATOR

        // TODO make additional noise maps for more better biomes
            // Wet map - the inverse of height map with blurred noise
            // Temperature map - a north/south gradient - terrain height with blurred noise
            // Civilizations - start with X number of cellular automata, define borders where they touch
                //for each border determine the relationship with neighbor
                    //if bad, add a chance for a warzone
                    //if good, trade route
                // For extra depth, run through this several times and add ancient/old/ruins adjectives to the parts that weren't overwritten
        public static void InitializeRandomBiomes() {
            BiomeOcean = new List<string>() {
                "I can't see the bottom",
                "Oceany stuff",
                "[ROWING LEVEL INCREASED]     Just kidding, that isn't a thing."
            };

            BiomeShallows = new List<string>() {
                "Jagged rocks stick up out of the sea.  Probably not a safe place for boating.",
                "The water is shallow here.",
                "There is a brightly colored reef, teeming with life.",
                "The reeds are especially dense.  Anything could be hiding in here."
            };

            BiomeLowlands = new List<string>() {
                "It's muddy",
                "Yuck."
            };

            BiomePlains = new List<string>() {
                "Grass, grass everywhere",
                "In the center of a ring of dead grass, there is a pillar stone standing barely above your head.",
                "More grass"
            };

            BiomeForest = new List<string>() {
                "Trees for days",
                "More trees",
                "The trees look angry here"
            };

            BiomeHighlands = new List<string>() {
                "Not much to see here.  Just rocks",
                "A deep crevice opens up in front of you.  You hear drums."
            };

            BiomeMountain = new List<string>() {
                "A rock catches your foot.  You trip.  A goat looks on judgementally.",
                "It's cold and barren.  Nothing could live here"
            };

            BiomePeaks = new List<string>() {
                "I can see my house from here",
                "It's cold"
            };
    }


    // Returns random location information from biome lists
    public static string[] GetRandomLocation(int height) {
            System.Random prng = new Random();
            string[] descriptionText = new string[2];
            if (height >= 0 && height < 4) {
                descriptionText[0] = "Ocean";
                descriptionText[1] = BiomeOcean.ElementAt(prng.Next(0, BiomeOcean.Count));
            }
            if (height == 4) {
                descriptionText[0] = "Shallows";
                descriptionText[1] = BiomeShallows.ElementAt(prng.Next(0, BiomeShallows.Count));
            }
            if (height == 5) {
                descriptionText[0] = "Lowlands";
                descriptionText[1] = BiomeLowlands.ElementAt(prng.Next(0, BiomeLowlands.Count));
            }
            if (height == 6) {
                descriptionText[0] = "Plains";
                descriptionText[1] = BiomePlains.ElementAt(prng.Next(0, BiomePlains.Count));
            }
            if (height == 7) {
                descriptionText[0] = "Forest";
                descriptionText[1] = BiomeForest.ElementAt(prng.Next(0, BiomeForest.Count));
            }
            if (height == 8) {
                descriptionText[0] = "Highlands";
                descriptionText[1] = BiomeHighlands.ElementAt(prng.Next(0, BiomeHighlands.Count));
            }
            if (height >= 9 && height < 12) {
                descriptionText[0] = "Mountains";
                descriptionText[1] = BiomeMountain.ElementAt(prng.Next(0, BiomeMountain.Count));
            }
            if (height == 12) {
                descriptionText[0] = "Peak";
                descriptionText[1] = BiomePeaks.ElementAt(prng.Next(0, BiomePeaks.Count));
            }


            return descriptionText;
        }

        #endregion

        #region DEVELOPER TOOLS
        public static string ListGameObjects(IEnumerable<GameObject> gameObjects) {
            // Display table name and column headers
            string messageBoxText =
                "Items\n" + "\n \n" +

                // Display table header
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Coordinates".PadRight(30) +
                "Owner".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(30) + "\n";

            // Display all collectible objects in rows
            string gameObjectRows = null;
            foreach (CollectibleObject gameObject in gameObjects) {
                if (gameObject is CollectibleObject) {
                    gameObjectRows +=
                        $"{gameObject.ID}".PadRight(10) +
                        $"{gameObject.Name}".PadRight(30);
                    if (gameObject.Owner != null) {
                        gameObjectRows += $"{gameObject.Owner.PosX}, {gameObject.Owner.PosY}".PadRight(30) +
                        $"{gameObject.Owner.Name}".PadRight(30);
                    } else {
                        gameObjectRows += $"{gameObject.xPos}, {gameObject.yPos}".PadRight(30) +
                        $"None".PadRight(30);
                    }
                    gameObjectRows += Environment.NewLine;
                }
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string ListAllLocations(IEnumerable<Location> locations) {
            // Display table name and column headers
            string messageBoxText =
                "Locations\n" + "\n \n" +

                // Display table header
                "Name".PadRight(30) +
                "Coordinates".PadRight(30) +
                "Explored".PadRight(30) + "\n" +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(30) + "\n";

            // Display all collectible objects in rows
            string gameObjectRows = null;
            foreach (Location location in locations) {
                gameObjectRows +=
                    $"{location.CommonName}".PadRight(30) +
                    $"{location.xCoord}, {location.yCoord}".PadRight(30) +
                    $"{location.Explored}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }
        #endregion

    }
}
