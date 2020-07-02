using System;

namespace Zuul
{
    public class Key : Item
    {
        // Constructor of base class Item is called with arguments
        public Key(string d, int w, bool b) : base(d, w, b)
        {
            this.description = d;
            this.weight = w;
            this.isBadItem = b;
        }

        // this method 'overrides' the 'virtual' method in base class Item.
        public override void Use()
        {
            Console.WriteLine("You heared a clicking sound from the door. It is now open!");
        }
    }
}