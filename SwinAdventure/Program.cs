namespace SwinAdventure
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string name, desc;
            Console.WriteLine("Enter player name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter player description: ");
            desc = Console.ReadLine();
            Player p = new Player(name, desc); //Setup player
            Location l = new Location(new string[] { "Start point" }, "start", "this is the start");
            p.Location = l;
            Location l2 = new Location(new string[] { "South point" }, "south", "this is the south");
            Path path = new Path(new string[] { "south" }, "door", "this is a door",l, l2);
            Path path1 = new Path(new string[] { "north" }, "door", "this is a door", l2, l);
            l.AddPath(path);
            l2.AddPath(path1);
            
            Location l4 = new Location(new string[] { "east point" }, "east", "this is the east");
            Path path2 = new Path(new string[] { "east" }, "door", "this is a door", l, l4);
            Path path3 = new Path(new string[] { "west" }, "door", "this is a door", l4, l); 
            l.AddPath(path2);
            l4.AddPath(path3);// setup location and path
            Item sword = new Item(new string[] { "sword" }, "sword", "this is a sword");
            Item shield = new Item(new string[] { "shield" }, "shield", "this is a shield");
            Item helmet = new Item(new string[] { "helmet" }, "helmet", "this is a helmet");
            Item boot = new Item(new string[] { "boot" }, "boot", "this is a boot");
            Item glove = new Item(new string[] { "glove" }, "glove", "this is a glove");
            Item gem  = new Item(new string[] { "gem" }, "gem", "this is a gem");
            l.Inventory.Put(sword);
            l2.Inventory.Put(shield);
            l2.Inventory.Put(helmet);// item in location
            Bag bag = new Bag(new string[] { "bag" }, $"{p.Name}'s bag", $"this is {p.Name}'s bag");
            p.Inventory.Put(boot);
            p.Inventory.Put(glove);
            bag.Inventory.Put(gem);
            p.Inventory.Put(bag);// item in player inventory
            string input;
            Command c = new CommandProcessor();
            do
            {
                Console.WriteLine("Enter command: ");
                input = Console.ReadLine();
                Console.WriteLine(c.Execute(p, input.ToLower().Split(' ')));
            } while (input != "exit");

            
             




        }
    }
}
