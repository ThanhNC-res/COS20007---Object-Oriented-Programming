using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WorldOfTanks
{
    public class Player2Tank : Tank
    {
        public Player2Tank()
        {
            size = 40; // siae of tank
            direction = Direction.North;
            hitpoints = 3;
            img = new Bitmap(Image.FromFile("../../TT34.png"), new Size(size, size));
        }
    }
}
