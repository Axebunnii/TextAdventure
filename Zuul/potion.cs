using System;

namespace Zuul
{
    public class Potion : Item
    {
        // Constructor of base class Item is called with arguments
        public Potion(string d, int w, bool b) : base(d, w, b)
        {
            this.description = d;
            this.weight = w;
            this.isBadItem = b;
        }

        // this method 'overrides' the 'virtual' method in base class Item.
        public override void Use()
        {
            Console.WriteLine("You drank the mysterious potion. Your health restored!");
        }
    }
}