using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject 
    { 
        private string _description;
        private string _name;
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual string ShortDescription
        {
            get { return _name; }
        }
        public virtual string FullDescription
        {
            get
            {
                return "The " + _name + " " + _description;
            }
        }
        public virtual string Description
        {
            get { return _description; }
        }
    }

    
    
}
