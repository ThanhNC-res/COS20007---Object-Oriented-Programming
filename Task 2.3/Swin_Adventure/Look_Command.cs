using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Look_Command : Command
    {
        public Look_Command() : base(new string[] { "look" }) { }

        public bool ContainsString(string searched, string[] value)
        {
            foreach (string s in value)
            {
                if (searched.Contains(s))
                    return true;
            }
            return false;
        }
        private string Look_At_In(string tId, IHaveInventory container)
        {
            if (container.Locate(tId) != null)
                return container.Locate(tId).FullDescription + "\r\n";

            return "Could not find " + tId + ".\r\n";
        }

        private IHaveInventory Fetch_Container(Player p, string containerid)
        {
            if (p != null)
                return p.Locate(containerid) as IHaveInventory;
            return null;
        }

        public override string Execute(Player p, string[] text)
        {
            string error = "Error Input";
            string look_error = "Error in look input";
            IHaveInventory _container;
            string _item;
            if (text[0].ToLower() == "look")
            {
                switch (text.Length)
                {
                    case 1:
                        _container = p as IHaveInventory;
                        switch (text[0])
                        {
                            case "look":
                                _item = "room";
                                break;
                            default:
                                _item = text[0];
                                break;
                        }
                        break;

                    case 2:
                        if (ContainsString(text[1].ToLower(), new string[] { "north",
                        "south", "east", "west", "up", "down", "around"  }))
                        {
                            _item = text[1];
                            _container = p as IHaveInventory;
                        }
                        else
                        {
                            _item = text[1];
                            _container = p as IHaveInventory;
                        }
                        break;

                    case 3:
                        if (text[1].ToLower() != "at")
                        {
                            return "What do you want to look at?";
                        }
                        _container = p as IHaveInventory;
                        _item = text[2];
                        break;

                    case 4:
                        switch (text[0])
                        {
                            case "examine":
                                _container = Fetch_Container(p, text[3]);
                                if (_container == null)
                                {
                                    return "Could not find " + text[3] + ".";
                                }
                                _item = text[1];
                                _container = p as IHaveInventory;
                                break;
                            default:
                                return error;

                        }
                        break;

                    case 5:
                        if (text[3].ToLower() != "in")
                        {
                            return "What do you want to look in?";
                        }
                        else
                            _container = Fetch_Container(p, text[4]);
                            if (_container == null)
                                return "Could not find " + text[4] + ".";
                            _item = text[2];
                        break;

                    default:
                        return error;
                }

                return Look_At_In(_item, _container);
            }

            return look_error;

        }
    }
}
