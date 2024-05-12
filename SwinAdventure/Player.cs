using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();

        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject gameObject = _inventory.Fetch(id);
            if (gameObject != null)
            {
                return gameObject;
            }
            if (_location != null)
            {
                gameObject = _location.Locate(id);
                return gameObject;
            }
            else
            {
                return null;
            }
        }
        public override string FullDescription
        {
            get
            {
                return "You are carrying: " + _inventory.ItemList;
            }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public void Move(Path path) 
        {
            if (path.Destination != null)
            {
                _location = path.Destination;
            }
        }
    }
    
}
