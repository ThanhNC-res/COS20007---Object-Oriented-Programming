using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Path : GameObject
    {
        bool _isBlocked;

        Location _from, _to;

        public Path(string[] idents, string name, string desc, Location from, Location to) :
            base(idents, name, desc)
        {
            Add_Identifier("path");
            foreach (string s in name.Split())
            {
                Add_Identifier(s);
            }

            From = from;
            To = to;
            _isBlocked = false;
        }
   


        public override string ShortDescription
        {
            get => Name;
        }

        public bool IsBlocked { get => _isBlocked; set => value = _isBlocked; }
        public Location From { get => _from; set => _from = value; }
        public Location To { get => _to; set => _to = value; }
    }
}
