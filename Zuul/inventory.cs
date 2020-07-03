using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Zuul
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();
        private int max_weight = 0;

        public Inventory(int mw)
        {
            //Console.WriteLine("Inventory ctor");
            this.max_weight = mw;
        }

        public int Put(Item item)
        {
            if (item != null)
            {
                if (this.TotalWeight() + item.weight < this.max_weight)
                {
                    items.Add(item);
                    return 1;
                }
                Console.WriteLine(item.description + " is too heavy!");
            }
            return 0;
        }

        // Remove by instance
        public Item Take(Item item)
        {
            if (items.Remove(item))
            {
                return item;
            }
            return null;
        }

        // Remove by description
        public Item Take(string desc)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].description == desc)
                {
                    Item item = items[i];
                    this.Take(item);
                    return item;
                }
            }
            return null;
        }

        public string Show()
        {
            string returnstring = "";
            for (int i = 0; i < items.Count; i++)
            {
                returnstring += items[i].Show();
            }
            if(returnstring == "")
            {
                returnstring = "There are no items in this room";
            }
            return returnstring;
        }

        private int TotalWeight()
        {
            int t = 0;
            for (int i = 0; i < items.Count; i++)
            {
                t += items[i].weight;
            }
            return t;
        }

        public bool Get(Item i)
        {
            if (items.Contains(i))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

