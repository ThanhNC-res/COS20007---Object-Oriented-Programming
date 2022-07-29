﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldOfTanks
{
    public abstract class Map
    {
        static public int size = 60; 
        static public Rectangle mainFrame; 
        public Point startPosition;
        public Point startPosition2;
        public List<Point> startPositionForBots; 
        public Bitmap eagle = new Bitmap(Image.FromFile("../../eagle.png"), new Size(60, 60));
        public Point pointEagle;
        public List<Point> forest = new List<Point>(); 
        public List<Point> brick = new List<Point>(); 
        public List<Point> stone = new List<Point>(); 
        public Bitmap imgStone = new Bitmap(Image.FromFile("../../stone.png"), new Size(60, 60));
        public Bitmap imgBrick = new Bitmap(Image.FromFile("../../brick.jpg"), new Size(20, 20));
        public Bitmap imgForest = new Bitmap(Image.FromFile("../../forest.png"), new Size(60, 60));

        static Map()
        {
            int x = (SystemInformation.VirtualScreen.Width - 13 * size) / 2;
            int y = (SystemInformation.VirtualScreen.Height - 13 * size) / 2;
            mainFrame = new Rectangle(new Point(x, y), new Size(size * 13, size * 13));
        }

        public Map()
        { 
            startPosition = new Point(mainFrame.X + 4 * size, mainFrame.Y + 12 * size);
            startPosition2 = new Point(mainFrame.X + 8 * size, mainFrame.Y + 12 * size);
            pointEagle = new Point(mainFrame.X + 6 * size, mainFrame.Y + 12 * size);
        }
    }
}
