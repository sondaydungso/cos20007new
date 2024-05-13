using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Move : Command
    {
        public Move() : base(new string[] { "move" })
        {
        }
        public override string Execute(Player p, string[] text)
        {
            string wrong = "I don't know how to move that";
            string direction;
            switch (text.Length)
            {
                case 1:
                    return "Move where?";
                case 2:
                     direction = text[1].ToLower();
                    
                    break;
                case 3:
                    direction = text[2].ToLower();
                    
                    break;
                default:
                    return wrong;
            }
            GameObject _path = p.Location.Locate(direction);
            
            if (_path == null)
            {
                return wrong;
            }
            else
            {
                if (_path.GetType() == typeof(Path))
                {
                    p.Move((Path)_path);
                    return $"You have moved to {_path.FirstID} ";
                }
                else
                {
                    return $"Ican not find the path {_path.Name}";
                }
            }
        }
    }   
    
}
