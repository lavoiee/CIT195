﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Entity, IBattle {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        #endregion


        #region PROPERTIES

        #endregion


        #region CONSTRUCTORS

        public Player() {
        }

        public Player(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int health, int maxHealth, int posX, int posY, int moveSpeed, List<CollectibleObject> inventory) : base(name, SpeciesType.Human, strength, dexterity, constitution, intelligence, wisdom, charisma, health, maxHealth, posX, posY, moveSpeed) {

        }

        #endregion


        #region METHODS

        public int GetAttack() {
            int hit = -1;
            if (new Random().Next(1, 101) < Dexterity * 10)
                hit = Strength;
            return hit;
        }

        #endregion
    }
}
