using System;

namespace Zuul
{
    public class Hammer : Item
    {
        // Constructor of base class Item is called with arguments
        public Hammer(string d, int w, bool b) : base(d, w, b)
        {
            this.description = d;
            this.weight = w;
            this.isBadItem = b;
        }

        // this method 'overrides' the 'virtual' method in base class Item.
        public override void Use()
        {
            Console.WriteLine("Hitting the nail on the head!");
        }
    }
}
