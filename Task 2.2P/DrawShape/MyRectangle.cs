using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }


        

       

        public MyRectangle(Color clr, int width, int height) : base(clr)
        {
            Width = width;
            Height = height;
        }
        public MyRectangle() : this(Color.RandomRGB(255), 150, 100) { }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
            if (Selected)
            {
                DrawOutline();
            }
        }

        
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }
        public override bool IsAt(Point2D pt)
        {
            if ((((pt.X >= _x) && (pt.X <= (_x + _width))) && (pt.Y >= _y) && (pt.Y <= (_y + _height))))
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
            //writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadForm(StreamReader reader)
        {
            base.LoadForm(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
    

