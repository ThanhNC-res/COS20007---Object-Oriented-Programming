using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    public class Message
    {
        private string _text;

        public Message(string txt)
        {
            _text = txt;
        }

        public void Print()
        {
            Console.WriteLine(_text);
        }
    }
}
