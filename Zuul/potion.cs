using System;

namespace Zuul
{
    public class Potion : Item
    {
        string Description;
        int Weight;

        // Constructor of base class Item is called with arguments
        public Potion(string d, int w) : base(d, w)
        {
            this.Description = d;
            this.Weight = w;
        }

        // this method 'overrides' the 'virtual' method in base class Item.
        public override void Use()
        {
            Console.WriteLine("Gluck, gluck, gluck. Health restored!");
        }
    }
}