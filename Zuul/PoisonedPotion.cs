using System;

namespace Zuul
{
    public class PiosonedPotion : Item
    {
        // Constructor of base class Item is called with arguments
        public PiosonedPotion(string d, int w, bool b) : base(d, w, b)
        {
            this.description = d;
            this.weight = w;
            this.isBadItem = b;
        }

        // this method 'overrides' the 'virtual' method in base class Item.
        public override void Use()
        {
            this.isBadItem = true;
            Console.WriteLine("You drank the mysterious potion. Too bad, it was poisoned");
        }

        public override void BadItem()
        {
            
        }
    }
}