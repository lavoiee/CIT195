using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    public abstract class GameObject {

        public abstract int ID { get; set; }
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract int xPos { get; set; }
        public abstract int yPos { get; set; }
        public abstract bool CanPickup { get; set; }
        public abstract bool CanDrop { get; set; }
        public abstract double Value { get; set; }
        public abstract ItemType Type {get; set;}
    }
}
