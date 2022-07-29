using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Counter
    {
        private string _part;
        private int _count;

        public Counter(string part, int count)
        {
            _part = part;
            _count = count;
        }

        public string Part { get => _part; set => _part = value; }
        public int Count { get => _count; set => _count = value; }

        public int CountIncre()
        {
            return _count += 1;
        }

        public int ResetCount()
        {
            return _count = 0;
        }

    }
}
