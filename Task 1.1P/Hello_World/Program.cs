using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Message myMessage;
            Message[] messages = new Message[4];
            string name;
            myMessage = new Message("Hello World! - from Message Object");
            myMessage.Print();

            messages[0] = new Message("Welcome back oh great educator!");
            messages[1] = new Message("What a lovely name");
            messages[2] = new Message("Great name");
            messages[3] = new Message("That a silly name!");

            bool stop;

            stop = true;
            while (stop == true)
            {
                Console.WriteLine("Enter Name: ");
                name = Console.ReadLine();

                if (name.ToLower() == "chris")
                {
                    messages[0].Print();
                }
                else if (name.ToLower() == "fred")
                {
                    messages[1].Print();
                }
                else if (name.ToLower() == "wilma")
                {
                    messages[2].Print();
                }
                else
                {
                    messages[3].Print();
                    stop = false;
                }
            }
            Console.ReadLine();
        }
    }
}
