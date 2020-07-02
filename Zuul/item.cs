using System;

using System;

namespace Zuul
{
    public abstract class Item
    {
        public string description { get; set; }
        public int weight { get; set; }
        public bool isBadItem { get; set; }

        public Item(string d, int w, bool b)
        {
            //Console.WriteLine("Item ctor");
            this.description = d;
            this.weight = w;
            this.isBadItem = b;
        }

        // this method is executed when called on a subclass.
        public string Show()
        {
            return " - " + this.description + ": weighs " + this.weight;
        }

        // this method is 'virtual', and should be 'override' in subclasses.
        public virtual void Use()
        {
            Console.WriteLine("Generic 'Use' method called");
        }

        public virtual void BadItem()
        {
            Console.WriteLine("Generic 'BadItem' method called");
        }
    }
}
