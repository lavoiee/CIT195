using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model {

    // TODO change the npc to an interface

    public abstract class Npc : Entity {

        public abstract int Id { get; set;  }

        public abstract string Description { get; set; }
    }
}
