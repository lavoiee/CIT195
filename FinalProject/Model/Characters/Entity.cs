using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// The base class for all characters and monsters
    /// </summary>
    public class Entity {
        #region ENUMERABLES

        public enum SpeciesType {
            None,
            Human,
            Beast,
            Bird
        }


        #endregion

        #region FIELDS

        protected string _name;

        protected int _strength;
        protected int _dexterity;
        protected int _constitution;
        protected int _intelligence;
        protected int _wisdom;
        protected int _charisma;

        protected int _maxStrength;
        protected int _maxDexterity;
        protected int _maxConstitution;
        protected int _maxIntelligence;
        protected int _maxWisdom;
        protected int _maxCharisma;

        protected int _health;
        protected int _maxHealth;
        protected bool _dead;

        protected SpeciesType _species;

        protected bool isUndead;

        protected int _posX;
        protected int _posY;
        protected int _moveSpeed;

        protected int _experience;
        protected List<CollectibleObject> _inventory;
        protected int _healthRegenTime = 20;
        protected int _healthRegenTimer = 20;

        protected bool _canPossess;
        protected Entity _possessedBy;
        protected Entity _possessing;


        #endregion

        #region PROPERTIES

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        #region Stats
        public int Strength {
            get { return _strength; }
            set { _strength = value; }
        }
        public int Dexterity {
            get { return _dexterity; }
            set { _dexterity = value; }
        }
        public int Constitution {
            get { return _constitution; }
            set { _constitution = value; }
        }
        public int Intelligence {
            get { return _intelligence; }
            set { _intelligence = value; }
        }
        public int Wisdom {
            get { return _wisdom; }
            set { _wisdom = value; }
        }
        public int Charisma {
            get { return _charisma; }
            set { _charisma = value; }
        }

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
            get { return _maxCharisma; }
            set { _maxCharisma = value; }
        }
        #endregion Stats

        public int Health {
            get { return _health; }
            set {
                if (value > _maxHealth)
                    _health = _maxHealth;
                else
                    _health = value;
            }
        }
        public int MaxHealth {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        public SpeciesType Species {
            get { return _species; }
            set { _species = value; }
        }

        public int xPos {
            get { return _posX; }
            set { _posX = value; }
        }
        public int yPos {
            get { return _posY; }
            set { _posY = value; }
        }

        public int MoveSpeed {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }
        public int Experience {
            get { return _experience; }
            set { _experience = value; }
        }

        public List<CollectibleObject> Inventory {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public bool CanPossess {
            get { return _canPossess; }
            set { _canPossess = value; }
        }

        public Entity PossessedBy {
            get { return _possessedBy; }
            set { _possessedBy = value; }
        }

        public Entity Possessing {
            get { return _possessing; }
            set { _possessing = value; }
        }

        public bool Dead {
            get { return _dead; }
            set { _dead = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Entity() {
            _inventory = new List<CollectibleObject>();
        }

        public Entity(string name, SpeciesType species) {
            _name = name;
            _species = species;
            _inventory = new List<CollectibleObject>();
        }


        public Entity(string name, SpeciesType species, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int health, int maxHealth, int posX, int posY, int moveSpeed) {
            _name = name;
            _species = species;
            _strength = strength;
            _dexterity = dexterity;
            _constitution = constitution;
            _intelligence = intelligence;
            _wisdom = wisdom;
            _charisma = charisma;
            _health = health;
            _maxHealth = maxHealth;
            _posX = posX;
            _posY = posY;
            _moveSpeed = moveSpeed;
            _inventory = new List<CollectibleObject>();
        }

        #endregion

        #region METHODS

        public void HealthRegen() {
            _healthRegenTimer--;
            if (_healthRegenTimer <= 0 && _health < _maxHealth) {
                _health++;
                _healthRegenTimer = _healthRegenTime;
            }
        }
        #endregion
    }
}
