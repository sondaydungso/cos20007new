using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        {

        }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 4)
            {
                return "Invalid put command";
            }
            
            if (p.Inventory.HasItem(text[1]))
            {
                Item fetchedItem = p.Inventory.Fetch(text[1]);
                
                IHaveInventory container = p.Locate(text[3]) as IHaveInventory;
                if (container != null)
                {
                    container.Put(fetchedItem);
                    p.Inventory.Take(text[1]);
                    return $"Item {fetchedItem.Name} has been put/dropped into {container.Name}.";

                }
                return $"Cannot find the {text[3]}";
            }
            return "You do not have " + text[1];
        }
    }
    
}
