using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTest
{
    public class Counter 
    {
        private int _count;
        private string _name;

        public Counter(string name)
        {
            Name = name;
            Count = 0;
        }

        public int Count { get => _count; set => _count = value; }
        public string Name { get => _name; set => _name = value; }


        public void Increment()
        {
            Count++;
        }

        public void Reset()
        {
            Count = 0;
        }

        public int Value
        {
            get
            {
                return Count;
            }
        }

        
    }
}
