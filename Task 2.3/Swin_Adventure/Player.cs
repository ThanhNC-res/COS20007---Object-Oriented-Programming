using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Inventory Inventory { get => _inventory;}
        public Location Location { get => _location; set => _location = value; }

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDescription
        {
            get
            {
                return "You are " + Name + ". " + Desc + ".";
            }
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
                return this;

            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
                return obj;
            if (_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }

        }

        public GameObject Take(string id)
        {
            return _inventory.Take(id);
        }

        public void Put(Item item)
        {
            _inventory.Put(item);
        }
        public void Move(Path path)
        {
            if (path.To != null)
            {
                _location = path.To;
            }
        }
    }
}
