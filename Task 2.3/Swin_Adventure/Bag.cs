using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Bag : Item, IHaveInventory
    {
        Inventory _inventory = new Inventory();

        public Bag(string[] ids, string name, string desc) :  base(new string[] { "Bag", "bag", "Bags", "bags", "BAG", "BAG" }, "Bags", "Bag")
        {

        }
        public Inventory Inventory { get => _inventory; }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
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
        public override string FullDescription
        {
            get
            {
                return "In the " + Name + " You can see " + _inventory.ItemList + "\n";
            }
        }


    }
}
