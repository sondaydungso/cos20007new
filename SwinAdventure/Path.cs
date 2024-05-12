using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        Location _source, _destination;
        public Path(string[] ids, string name, string desc, Location source, Location destination) : base(ids, name, desc)
        {
            _destination = destination;
            _source = source;
            foreach (string n in name.Split(' '))
            {
                AddIdentifier(n);
            }
        }
        public Location Destination
        {
            get { return _destination; }
        }
        public Location Source
        {
            get { return _source; }
        }
        public override string ShortDescription
        {
            get
            {
                return "This path connects " + _source.Name + " to " + _destination.Name + ". " + base.FullDescription;
            }
        }

    }
    
}
