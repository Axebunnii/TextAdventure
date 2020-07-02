using System;

namespace Zuul
{
    public class Knife : Item
    {
        // Constructor of base class Item is called with arguments
        public Knife(string d, int w, bool b) : base(d, w, b)
        {
            this.description = d;
            this.weight = w;
            this.isBadItem = b;
        }

        // this method 'overrides' the 'virtual' method in base class Item.
        public override void Use()
        {
            
        }

        public override void BadItem()
        {
            Console.WriteLine("Oh no! You cut yourself on the knife while picking it up.\nThe wound looks pretty bad.");
        }
    }
}
