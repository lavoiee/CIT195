using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Human {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        bool _isPossessing = false;
        double _age;

        #endregion


        #region PROPERTIES

        public bool IsPossessing {
            get { return _isPossessing; }
            set { _isPossessing = value; }
        }
        public double Age {
            get { return _age; }
            set { _age = value; }
        }


        #endregion


        #region CONSTRUCTORS

        public Player() {
        }

        public Player(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int health, int maxHealth, int posX, int posY, int moveSpeed, List<CollectibleObject> inventory) : base(name, strength, dexterity, constitution, intelligence, wisdom, charisma, health, maxHealth, posX, posY, moveSpeed) {

        }

        #endregion


        #region METHODS

        #endregion
    }
}
