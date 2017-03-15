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
        private int _locationID; // must be a unique value for each object
        private string _description;
        private bool _accessable;
        private int _experiencePoints;

        #endregion


        #region PROPERTIES

        public string CommonName {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int LocationID {
            get { return _locationID; }
            set { _locationID = value; }
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

        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
