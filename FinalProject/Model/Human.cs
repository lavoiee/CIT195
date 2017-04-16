using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Human : Entity {
        #region ENUMERABLES


        #endregion

        #region FIELDS
        private int _maxStrength;
        private int _maxDexterity;
        private int _maxConstitution;
        private int _maxIntelligence;
        private int _maxWisdom;
        private int _maxCharisma;

        #endregion


        #region PROPERTIES
        public int MaxStrength {
            get { return _maxStrength; }
            set { _maxStrength = value; }
        }

        public int MaxDexterity {
            get { return _maxDexterity; }
            set { _maxDexterity = value; }
        }

        public int MaxConstitution {
            get { return _maxConstitution; }
            set { _maxConstitution = value; }
        }

        public int MaxIntelligence {
            get { return _maxIntelligence; }
            set { _maxIntelligence = value; }
        }

        public int MaxWisdom {
            get { return _maxWisdom; }
            set { _maxWisdom = value; }
        }

        public int MaxCharisma {
            get { return _maxCharisma;  }
            set { _maxCharisma = value;  }
        }

        #endregion


        #region CONSTRUCTORS

        public Human() {

        }
        // TODO unfuck constructors
        public Human(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int health, int maxHealth, int posX, int posY, int moveSpeed) : base(name, SpeciesType.Human, strength, dexterity, constitution, intelligence, wisdom, charisma, health, maxHealth, posX, posY, moveSpeed) {

        }

        #endregion


        #region METHODS


        #endregion
    }
}
