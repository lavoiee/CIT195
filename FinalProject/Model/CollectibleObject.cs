using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    public class CollectibleObject : GameObject {
        public override int ID { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int xPos { get; set; }
        public override int yPos { get; set; }
        public override bool CanPickup { get; set; }
        public override bool CanDrop { get; set; }
        public override ItemType Type { get; set; }
        public override double Value { get; set; }
        public Entity Owner { get; set; }
        public bool IsUseable { get; set; }
        public int HealingValue { get; set; }
    }
}
