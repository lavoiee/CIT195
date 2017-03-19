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
        public static List<string> FooterText = new List<string>() { "Lichty, 2017" };

        #region INTITIAL GAME SETUP

        public static string IntroductionP1() {
            string messageBoxText =
                "\tYou live in a small village with your father.  The townsfolk say your mother died in childbirth, but then \n" +
                "\t  they also say your parents were once great sorcerors and heros.  They can't be trusted.  Your mother was \n" +
                "\t  probably just another whore and your father has never anything more than a worthless drunk.";

            return messageBoxText;
        }

        public static string IntroductionP2() {
            string messageBoxText =
                "\tSomething feels different as you shake the rain from your cloak in the entryway of your run down house.\n" +
                "\t  In the light of the open door, you notice muddy footprints amidst the flith covering the floor.  There is \n" +
                "\t  a sickening retch from the other room.  You relax.  Maybe father will pass out early tonight.  You enter \n" +
                "\t  the room to see his familiar frame sprawled out next to an array of empty bottles.  One, still half \n" +
                "\t  empty, rests in the center of the floors newest stain.  Another retching gasp drowns out your father's \n" +
                "\t  snores.  You spin just in time to see the disemboweled dog lunge at your face.  A chain leaps and the dog \n" +
                "\t  jerks to a stop.  The momentum of the animal's sagging organs carries their gore over your rain soaked \n" +
                "\t  cloak.  It growls and strains against the chain.  This was the baker's dog!  How is this creature alive? \n" +
                "\t  You notice a leather bound book outside the ring of gore soaking through the floorboards.  It calls to you.  \n \n" +
                "\t  You pick it up an begin to read...";

            return messageBoxText;
        }

        public static string SpellSelection() {
            string messageText = "Spell Selection";
            return messageText;
        }

        public static string IntroductionP3() {

            string messageBoxText =
                "\tThe pain blossoming from your back breaks you free from the book's grasp.  Dazed, you recognize the baker's \n" +
                "\t  voice as he slams a mallet against the base of your skull.  You slump to the ground.  You're dimly aware \n" +
                "\t  of other voices in the room, the smell of torches, the sound of tearing wood.  The dog is free.  It tears \n" +
                "\t  the throat from its former master.  The other voices panic as the undead animal shrugs off their blows. \n" +
                "\t  Father grunts in his fitful sleep.  A man swings his torch at the animal.  The scent of burning hair fills \n" +
                "\t  the room.  Father screams.  You drag yourself out the back door as the walls begin to blister.";
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

        public static string PlayerInventory() {
            string messageBoxText = "You don't have any items.";

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
    }
}
