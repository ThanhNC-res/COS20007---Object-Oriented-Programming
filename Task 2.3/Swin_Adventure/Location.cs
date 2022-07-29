using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {
        Inventory _inventory;
        List<Path> _paths;

        public Inventory Inventory { get => _inventory; }
        public Location(string name, string desc) : base(new string[] { "location", "place", "room" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();

        }
        public Location(string name, string desc, List<Path> paths) :
          this(name, desc)
        {
            _paths = paths;

        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                    return p;
            }
            return _inventory.Fetch(id);
             
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
                return "Your location is " + Name + ". " + Desc + ".";
            }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public string PathList
        {
            get
            {
                string list = string.Empty + "\r\n";


                if (_paths.Count == 1)
                {
                    return "\r\n\nThere is an exit " + _paths[0].FirstId + ".\r\n";
                }

                list = list + "There are exits to the ";

                for (int i = 0; i < _paths.Count; i++)
                {

                    if (i == _paths.Count - 1)
                    {
                        list = list + "and " + _paths[i].FirstId + ".\r\n";
                    }
                    else
                    {
                        list = list + _paths[i].FirstId + ", ";
                    }
                }
                return list;
            }
        }

        public bool HasPath(string direction)
        {
            foreach (Path p in _paths)
            {
                if (p.FirstId.ToLower() == direction.ToLower())
                    return true;
            }
            return false;
        }



    }
}
