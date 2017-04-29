using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// class for the game map locations
    /// </summary>

    public class Location {
        #region FIELDS

        private string _commonName;
        private int _xCoord;
        private int _yCoord;
        private string _description;
        private bool _accessable;
        private int _experiencePoints;
        private bool _explored;
        private bool _generic;

        #endregion


        #region PROPERTIES

        public string CommonName {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int xCoord {
            get { return _xCoord; }
            set { _xCoord = value; }
        }
    
        public int yCoord {
            get { return _yCoord; }
            set { _yCoord = value; }
        }

        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessable {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public int ExperiencePoints {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public bool Explored {
            get { return _explored; }
            set { _explored = value; }
        }

        public bool Generic {
            get { return _generic; }
            set { _generic = value; }
        }

        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
