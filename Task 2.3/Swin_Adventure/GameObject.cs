using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class GameObject : Identifiable_Object
    {
        private string _description;
        private string _name;
        private Identifiable_Object _identifiable_Object;
        

        public GameObject(string[] ids, string Name, string Desc) : base(ids)
        {
            _name = Name;
            _description = Desc;
        }

        public string Name { get => _name; }
        public string Desc { get => _description; }
        public virtual string ShortDescription
        {
            get
            {
                return  _description;
            }
        }

        public virtual string FullDescription
        {
            get
            {
                return "You are carrying: " + _description;
            }

        }
    }
}
