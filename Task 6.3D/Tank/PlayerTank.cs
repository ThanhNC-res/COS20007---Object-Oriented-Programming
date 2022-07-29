using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldOfTanks
{
    public class PlayerTank : Tank
    {
        public PlayerTank()
        {
            size = 40; // size of tank
            direction = Direction.North;
            hitpoints = 3;
            img = new Bitmap(Image.FromFile("../../TT35.png"), new Size(size, size));
        }
    }
}
