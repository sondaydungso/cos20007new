using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container;
            string _itemID;

            if ((text.Length != 3) && (text.Length != 5))
            {

                return "I don't know how to look like that";
            }

            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 3)
            {
                _container = p;
                _itemID = text[2];
                if (_container.Locate(_itemID) is null)
                {
                    return $"I can't find the {text[2]}";
                }
                else
                {
                    return _container.Locate(_itemID).FullDescription;
                }
            }
            else
            {
                if (text.Length == 5 && text[3].ToLower() != "in")
                {
                    return "What do you want to look in?";
                }
                _container = FetchContainer(p, text[4]);
                if (_container is null)
                {
                    return $"I can't find the {text[4]}";
                }
                _itemID = text[2];
            }
            return LookAtIn(_itemID, _container);
        }

        private IHaveInventory? FetchContainer(Player p, string containerID)
        {
            
            return p.Locate(containerID) as IHaveInventory;
        }

        private string LookAtIn(string thingID, IHaveInventory container)
        {
            if (container.Locate(thingID) is null)
            {
                return $"I can't find the {thingID}";
            }
            else
            {
                return container.Locate(thingID).FullDescription;
            }
        }
    }

}
