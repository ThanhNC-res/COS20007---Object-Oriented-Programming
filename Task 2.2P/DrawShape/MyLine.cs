using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endx, _endy;

        public float Endx { get => _endx; set => _endx = value; }
        public float Endy { get => _endy; set => _endy = value; }

        public MyLine(Color color, float endX, float endY) : base(color) { }
        public MyLine() : this(Color.RandomRGB(255), 100, 100) { }
        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, Endx, Endy);
            if (Selected)
            {
                DrawOutline();
            }
        }
        public override bool IsAt(Point2D pt)
        {

            if (SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, Endx, Endy)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void DrawOutline()
        {
            float radius = 5f;
            SplashKit.FillCircle(Color.Black, X, Y, radius);
            SplashKit.FillCircle(Color.Black, Endx, Endy, radius);
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endx);
            writer.WriteLine(_endy);
        }
        public override void LoadForm(StreamReader reader)
        {
            base.LoadForm(reader);
            Endx = reader.ReadSingle();
            Endy = reader.ReadSingle();
        }
    }

}
