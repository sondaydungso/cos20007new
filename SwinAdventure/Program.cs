namespace SwinAdventure
{
    public class Program
    {
        static void LookCommandExe(Command c, string input, Player p)
        {
            Console.WriteLine(c.Execute(p, input.Split()));

        }
        static void Main(string[] args)
        {
            string name, desc;
            Console.WriteLine("Enter player name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter player description: ");
            desc = Console.ReadLine();
            Player p = new Player(name, desc);
            
            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a mighty fine shovel");
            Item sword = new Item(new string[] { "sword" }, "a sword", "This is a mighty fine sword");
            Item gem = new Item(new string[] { "gem" }, "a gem", "This is a mighty fine gem");
            Item keyboard = new Item(new string[] { "keyboard" }, "a keyboard", "This is a mighty fine keyboard");
            Item mouse = new Item(new string[] { "mouse" }, "a mouse", "This is a mighty fine mouse");
            Item monitor = new Item(new string[] { "monitor" }, "a monitor", "This is a mighty fine monitor");

            Bag bag = new Bag(new string[] { "bag" }, "a bag", "This is a mighty fine bag");

            Command c = new LookCommand();

            Location myplace = new Location(new string[] { "here" }, "myplace", "This is my place");

            p.Inventory.Put(shovel);
            p.Inventory.Put(sword);
            
            p.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            string _answer;


            p.Location = myplace;
            
            myplace.Inventory.Put(keyboard);
            myplace.Inventory.Put(mouse);
            myplace.Inventory.Put(monitor);
            while (true)
            {
                Console.WriteLine("Enter command: ");
                _answer = Console.ReadLine();
                if (_answer == "exit")
                {
                    break;
                }
                else
                {
                    LookCommandExe(c, _answer, p);
                }
            }


        }
    }
}
