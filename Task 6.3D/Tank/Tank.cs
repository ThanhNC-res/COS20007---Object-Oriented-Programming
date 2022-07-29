using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTanks
{
    public abstract class Tank
    {
        public int size;
        public Direction direction; // Move direction of the tank
        public Direction_2 direction_2;
        public Dictionary<Direction, KeyValuePair<int, int>> shift; // displacement of the tank depending on the direction of movement
        public Dictionary<Direction_2, KeyValuePair<int, int>> shift_2;
        public int hitpoints; //number of lives
        public Point point; // top-left coordinates
        public Bitmap img; // picture for a tank
        public Dictionary<Direction, int> windRose = new Dictionary<Direction, int>();
        public Dictionary<Direction_2, int> windRose_2 = new Dictionary<Direction_2, int>();
        public bool isShooting = false; 

        public Tank()
        {
            shift = new Dictionary<Direction, KeyValuePair<int, int>>();
            shift_2 = new Dictionary<Direction_2, KeyValuePair<int, int>>();

            shift.Add(Direction.North, new KeyValuePair<int, int>(0, -5));
            shift.Add(Direction.South, new KeyValuePair<int, int>(0, 5));
            shift.Add(Direction.East, new KeyValuePair<int, int>(5, 0));
            shift.Add(Direction.West, new KeyValuePair<int, int>(-5, 0));

            shift_2.Add(Direction_2.North, new KeyValuePair<int, int>(0, -5));
            shift_2.Add(Direction_2.South, new KeyValuePair<int, int>(0, 5));
            shift_2.Add(Direction_2.East, new KeyValuePair<int, int>(5, 0));
            shift_2.Add(Direction_2.West, new KeyValuePair<int, int>(-5, 0));

            windRose.Add(Direction.North, 0);
            windRose.Add(Direction.East, 90);
            windRose.Add(Direction.West, 270);
            windRose.Add(Direction.South, 180);

            windRose_2.Add(Direction_2.North, 0);
            windRose_2.Add(Direction_2.East, 90);
            windRose_2.Add(Direction_2.West, 270);
            windRose_2.Add(Direction_2.South, 180);

        }
    }
}
