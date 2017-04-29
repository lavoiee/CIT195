using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    public class Relationship {

        private int _anger;
        private int _love;
        private int _hate;
        private int _fear;

        public int Anger {
            get { return _anger; }
            set { _anger = value; }
        }

        public int Love {
            get { return _love; }
            set { _love = value; }
        }

        public int Hate {
            get { return _hate; }
            set { _hate = value; }
        }

        public int Fear {
            get { return _fear; }
            set { _fear = value; }
        }


    }
}
