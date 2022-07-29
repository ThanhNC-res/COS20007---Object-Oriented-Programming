using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class CommandProcesscer : Command
    {
        List<Command> _commands;

        public CommandProcesscer() : base(new string[] { "command" })
        {
            _commands = new List<Command>();
            _commands.Add(new Look_Command());
            _commands.Add(new Move());
            _commands.Add(new Take());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command c in _commands)
            {
                if (c.AreYou(text[0].ToLower()))
                    return c.Execute(p, text);
            }

            return "Error in Command input";
        }
    }
}
