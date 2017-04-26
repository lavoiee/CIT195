using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model {
    class WorldObject : GameObject {
        public override int ID { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int xPos { get; set; }
        public override int yPos { get; set; }
        public override bool CanPickup { get; set; }
        public override bool CanDrop { get; set; }
        public ItemType Type { get; set; }
        public override double Value { get; set; }
    }
}
