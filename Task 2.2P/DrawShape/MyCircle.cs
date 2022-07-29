using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _r;

        public int R { get => _r; set => _r = value; }

        public MyCircle(Color color, int r) : base(color)
        {
            R = r;
        }


        public MyCircle() : this(Color.RandomRGB(255), 50) { }

        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, R);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X - 2, Y - 2, R + 2);
        }


        public override bool IsAt(Point2D pt)
        {
            if ((((pt.X >= _x) && (pt.X <= (_x + _r))) && (pt.Y >= _y) && (pt.Y <= (_y + _r))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(R);
        }

        public override void LoadForm(StreamReader reader)
        {
            base.LoadForm(reader);
            R = reader.ReadInteger();
        }
    }
}
