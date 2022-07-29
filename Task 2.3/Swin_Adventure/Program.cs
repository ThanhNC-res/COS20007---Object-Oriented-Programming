using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swin_Adventure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Swin_Adventure
    {
        class Program
        {
            public static void ColoredConsoleWrite(ConsoleColor color, string text)
            {
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ForegroundColor = originalColor;
            }
            public static void ConsoleColorWriteLine(ConsoleColor color, string text)
            {
                ConsoleColor Color = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ForegroundColor = Color;
            }


            static void Main(string[] args)
            {
                string _input;


                Console.WriteLine();

                Console.Write("                                                  ");
                Console.WriteLine("Welcome to: ");
                ConsoleColorWriteLine(ConsoleColor.Green, @"   _____      _____  _____________________ __________ ____ __________    _______  _____________________ ");
                ConsoleColorWriteLine(ConsoleColor.Green, @"  /     \    /  _  \ \____    /\_   _____/ \______   \    |   \      \   \      \ \_   _____/\______   \");
                ConsoleColorWriteLine(ConsoleColor.Green, @" /  \ /  \  /  /_\  \  /     /  |    __)_   |       _/    |   /   |   \  /   |   \ |    __)_  |       _/");
                ConsoleColorWriteLine(ConsoleColor.Green, @"/    Y    \/    |    \/     /_  |        \  |    |   \    |  /    |    \/    |    \|        \ |    |   \");
                ConsoleColorWriteLine(ConsoleColor.Green, @"\____|__  /\____|__  /_______ \/_______  /  |____|_  /______/\____|__  /\____|__  /_______  / |____|_  /");
                ConsoleColorWriteLine(ConsoleColor.Green, @"        \/         \/        \/        \/          \/                \/         \/        \/         \/ ");
                Console.WriteLine(".");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("This is version 0.1 'MAZE ESCAPER OST' | Iteration 5,6 in Progress. ");
                Console.WriteLine();
                Console.WriteLine("What is your name?");
                string name = Console.ReadLine();
                Console.WriteLine("How can you describe yourself? (e.g. 'A great Conquerer')");
                string description = Console.ReadLine() + "!";
                Console.WriteLine();
                Console.WriteLine(name + ", " + description + " It's time to join a fantasy world ");
                Console.WriteLine();

                Player player = new Player(name, description);
                Bag Bag = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag endorned with a 6-petal star atop a circle.");

                Item Portion = new Item(new string[] { "portion" }, "red", "A small healing item");
                Item Gem = new Item(new string[] { "gem" }, "phosphophyllite", "An emerald-green gem of about three-and-a-half hardness. Pretty.");
                Item Map = new Item(new string[] { "map" }, "world map", "the world map of this game, help you to find the true way.");
                Item Longsword = new Item(new string[] { "Longsword" }, "Long", "a popular weapon for a knight");
                Item ArmorTable = new Item(new string[] { "ArmorTable" }, "Armor", "Find suitable armor");
                Item Bot = new Item(new string[] { "bot" }, "bot", "Monster bots");

                Location WeaponRoom = new Location("WeaponRoom", "You're in weapon room where you can attach for youself some usefull equipments " +
                    "\r\nStart to choose you favourite weapon and get ready to conquer this journey. ");
                Location PraticeRoom = new Location("PraticeRoom", "Now you have put your foot in Practice Room, where you can enhace your skill");
                Location BotRoom = new Location("Bot", "You are in Farm room, where you can kill bots and earn gold and exprience");
                Location FightArena = new Location("FightArena", "You are in fight room, where you will fight with other knight from many other place");

                Path WroomtoProom = new Path(new string[] { "north" }, "Practice Entrance", "Go to practice room", WeaponRoom, PraticeRoom);
                Path WroomtoBroom = new Path(new string[] { "south" }, "Bot Room Entrance", "Go to Bot Room", WeaponRoom, BotRoom);
                Path ProomtoFroom = new Path(new string[] { "west" }, "Arena Entrance", "Go to Fight Arena", PraticeRoom, FightArena);


                player.Location = WeaponRoom;

                player.Inventory.Put(Portion);
                player.Inventory.Put(Bag);
                Bag.Inventory.Put(Longsword);
                Bag.Inventory.Put(Map);
                Bag.Inventory.Put(Gem);

                BotRoom.Inventory.Put(Bot);
                WeaponRoom.Inventory.Put(ArmorTable);

                WeaponRoom.AddPath(WroomtoBroom);
                WeaponRoom.AddPath(WroomtoProom);
                PraticeRoom.AddPath(ProomtoFroom);


                Command c = new CommandProcesscer();
                Console.ForegroundColor = ConsoleColor.DarkGray;

                while (true)
                {

                    Console.Write("Command--> ");

                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Gray;


                    _input = Console.ReadLine();

                    Console.ForegroundColor = originalColor;

                    Console.WriteLine();
                    ColoredConsoleWrite(ConsoleColor.Cyan, (c.Execute(player, _input.Split())));
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }



    }
}
