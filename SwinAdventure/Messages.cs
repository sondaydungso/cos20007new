using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Messages
    {
        private string _message;
        public Messages(string message)
        {
            _message = message;
        }
        public void ShowMessage()
        {
            Console.WriteLine(_message);
        }
    }
}
