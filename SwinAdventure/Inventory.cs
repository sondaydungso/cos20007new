using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public Item Take(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    _items.Remove(itm);
                    return itm;
                }
            }
            return null;
        }
        public Item Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return itm;
                }
            }
            return null;
        }
        public string ItemList
        {
            get
            {
                string result = "";
                foreach (Item itm in _items)
                {
                    result += itm.ShortDescription + " ";
                }
                return result;
            }
        }
    }
}
