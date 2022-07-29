using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Put : Command
    {
        public Put() : base(new string[] { "put", "throw" })
        {

        }

        public bool ContainsString(string searched, string[] value)
        {
            foreach (string s in value)
            {
                if (searched.Contains(s))
                    return true;
            }
            return false;
        }

        public override string Execute(Player p, string[] text)
        {

            IHaveInventory _container = null;
            string _itemid;
            string error = "Error in take input.";

            switch (text.Length)
            {
                case 1:
                    return "Put what?";
                case 2:

                    if (ContainsString(text[1].ToLower(), new string[] {"north",
                        "south", "east", "west", "up", "down" }))
                    {
                        return "Cannot put" + text[0] + " direction!";
                    }
                    else
                    {
                        _itemid = text[1];
                        _container = p.Location as IHaveInventory;
                    }
                    break;
                case 3:
                    if (text[1].ToLower() != "in")
                        return "What do you want to put in?";
                    _container = p.Inventory as IHaveInventory;
                    _itemid = text[2];
                    break;
                case 4:
                    _container = FetchContainer(p, text[3]);
                    if (_container == null)
                        return "Could not find " + text[3] + ".\r\n";
                    _itemid = text[1];
                    break;

                default:
                    _container = null;
                    return error;


            }
            return PutItemFrom(p, _itemid, _container);

        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private String PutItemFrom(Player p, string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
                return "Could not find " + thingId + "\r\n";

            GameObject _itemFound  = container.Locate(thingId);
            Item itemGrabbed = p.Inventory.Take(thingId) as Item;
            if (itemGrabbed == null)
                return "You can't put " + _itemFound.ShortDescription + " with you.\r\n";
            container.Put(itemGrabbed);

            return "You have taken the " + thingId + ".\r\n";
        }
    }
}
