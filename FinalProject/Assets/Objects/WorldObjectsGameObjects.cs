using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    /// <summary>
    /// A partial class to hold all GameObject objects in the game world
    /// </summary>
    public static partial class WorldObjects {
        public static IEnumerable<GameObject> Objects = new List<GameObject>() {
            new CollectibleObject
            {
                ID = 1,
                Name = "Sharp stick",
                Description = "It's brown and sticky.",
                xPos = 1300,
                yPos = 850
            },
            new CollectibleObject
            {
                ID = 2,
                Name = "Brick",
                Description = "Red.  Bad for your teeth.",
                xPos = 1360,
                yPos = 863,
                IsUseable = true,
                Type = ItemType.Consumable,
                HealingValue = -5
            },
        new CollectibleObject
            {
                ID = 3,
                Name = "Cloak",
                Description = "It has lot's of little pockets.",
                xPos = 1300,
                yPos = 850
            },
        new CollectibleObject
            {
                ID = 4,
                Name = "Book",
                Description = "It's all spooky and stuff.",
                xPos = 1332,
                yPos = 867
            },
        new CollectibleObject
            {
                ID = 5,
                Name = "Dull Axe",
                Description = "It has a great personality.",
                xPos = 1370,
                yPos = 860
            },
        new CollectibleObject
            {
                ID = 6,
                Name = "Health potion",
                Description = "Magically mundane!",
                xPos = 1301,
                yPos = 835,
                Type = ItemType.Consumable,
                IsUseable = true,
                HealingValue = 45
            },
        new CollectibleObject
            {
                ID = 7,
                Name = "Bread",
                Description = "It's whole wheat.",
                xPos = 1300,
                yPos = 851,
                Type = ItemType.Consumable,
                IsUseable = true,
                HealingValue = 5
            },
        new CollectibleObject
            {
                ID = 8,
                Name = "Hiking boots",
                Description = "They stink.",
                xPos = 1321,
                yPos = 859
            },
        new CollectibleObject
            {
                ID = 9,
                Name = "Blacksmith hammer",
                Description = "Iron... heads... it works for both.",
                xPos = 1289,
                yPos = 853
            }
};
    }
}
