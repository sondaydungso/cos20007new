using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "take" }) { }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 4)
            {
                return "Invalid Command";
            }
            if (p.Inventory.HasItem(text[1]))
            {
                return "You already have " + text[1];
            }
            IHaveInventory container = p.Locate(text[3]) as IHaveInventory;
            if (container == null)
            {
                return "I cannot find the " + text[3];
            }
            Item takenItem = container.Take(text[1]);
            p.Put(takenItem);
            return $"You have taken {takenItem.Name}";
        }
    }
}
