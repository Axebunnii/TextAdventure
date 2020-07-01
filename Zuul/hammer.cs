using System;

namespace Zuul
{
    public class Hammer : Item
    {
        string Description;
        int Weight;

        // Constructor of base class Item is called with arguments
        public Hammer(string d, int w) : base(d, w)
        {
            this.Description = d;
            this.Weight = w;
            Console.WriteLine("Hammer ctor");
        }

        // this method 'overrides' the 'virtual' method in base class Item.
        public override void Use()
        {
            Console.WriteLine("Hitting the nail on the head!");
        }
    }
}
