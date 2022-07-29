using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public enum Stage
    {
        EnterName,
        EnterDesc,
        Begin

    }
    public class InputForm
    {
        string _output;
        Stage _stage;
        string _name, _desc;
        Player player1;

        Command c = new CommandProcesscer();
       
       
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

      


        public InputForm()
        {
           
            Path WroomtoProom = new Path(new string[] { "north" }, "Practice Entrance", "Go to practice room", WeaponRoom, PraticeRoom);
            Path WroomtoBroom = new Path(new string[] { "south" }, "Bot Room Entrance", "Go to Bot Room", WeaponRoom, BotRoom);
            Path ProomtoFroom = new Path(new string[] { "west" }, "Arena Entrance", "Go to Fight Arena", PraticeRoom, FightArena);

           
            Bag.Inventory.Put(Longsword);
            Bag.Inventory.Put(Map);
            Bag.Inventory.Put(Gem);

            BotRoom.Inventory.Put(Bot);
            WeaponRoom.Inventory.Put(ArmorTable);

            WeaponRoom.AddPath(WroomtoBroom);
            WeaponRoom.AddPath(WroomtoProom);
            PraticeRoom.AddPath(ProomtoFroom);

            _output = "Welcome to MazeRunner!\n " +
                "\n" +
                "What is your name?\n";
            _stage = Stage.EnterName;
        }

        public string Output { get => _output; }

        public string EnterCommand(string text)
        {
            switch (_stage)
            {
                case Stage.EnterName:
                    _name = text;
                    _stage = Stage.EnterDesc;
                    return "How can you describe yourself? (e.g. 'A great Conquerer')\n";
                case Stage.EnterDesc:
                    _desc = text;
                    player1 = new Player(_name, _desc);
                    _stage = Stage.Begin;

                    player1.Location = WeaponRoom;

                    player1.Inventory.Put(Portion);
                    player1.Inventory.Put(Bag);

                    return "Welcome back!" + _name + ", " + _desc + " It's time to join a fantasy world\n ";
            }
            return c.Execute(player1, text.Split());
        }
    }
        
}
