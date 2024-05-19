namespace SwinAdventure
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string name, desc;
            string help = "Commands: \n" +
                "Look: Look at the location\n" +
                "Go: Go to a location\n" +
                "Take: Take an item\n" +
                "Drop: Drop an item\n" +
                "Inventory: Check your inventory\n" +
                "Help: Display this help message\n" +
                "Exit: Exit the game\n";
            Console.WriteLine("Enter player name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter player description: ");
            desc = Console.ReadLine();
            Player player = new Player(name, desc);// setup player
            
            Location l1 = new Location(new string[] { "location", "myplace1" }, "myplace1", "This is my place");
            player.Location = l1;
            Location l2 = new Location(new string[] { "location" }, "myplace2", "This is my place");
            Path path = new Path(new string[] { "south" , "Path1" }, "Path1", "This is a path", l1, l2);
            Path path1 = new Path(new string[] { "north", "Path2" }, "Path2", "This is a path", l2, l1);
            l1.AddPath(path);
            l2.AddPath(path1);// player location and path
            Item gem = new Item(new string[] { "gem" }, "a gem", "this is a gem");
            Item sword = new Item(new string[] { "sword" }, "a sword", "this is a sword");
            Item shield = new Item(new string[] { "shield" }, "a shield", "this is a shield");
            Item helmet = new Item(new string[] { "helmet" }, "a helmet", "this is a helmet");
            Item potion = new Item(new string[] { "potion" }, "a potion", "this is a potion");  
            Bag bag = new Bag(new string[] { "bag" }, "bag", "this is a bag");
            l1.Inventory.Put(gem);
            l1.Inventory.Put(sword);
            l2.Inventory.Put(potion);// items and bag
            player.Inventory.Put(shield);
            bag.Inventory.Put(helmet);
            player.Inventory.Put(bag);


            string input;
            Command c = new CommandProcessor();
            
            do
            {
                Console.WriteLine("Enter command: ");
                input = Console.ReadLine();
                if (input.ToLower() == "help")
                {
                    Console.WriteLine(help);
                }
                if (input.ToLower() != "exit" && input.ToLower() != "help")
                {
                    Console.WriteLine(c.Execute(player, input.ToLower().Split(' ')));
                }


                
            } while (input != "exit");

            
             




        }
    }
}
