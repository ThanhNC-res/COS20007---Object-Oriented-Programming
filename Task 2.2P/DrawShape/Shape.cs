using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        protected double _x, _y;
        private bool _selected;
      
        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type>();

        public Color Color { get => _color; set => _color = value; }
        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public bool Selected { get => _selected; set => _selected = value; }

        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }

        public static string Key(Type kind)
        {
            foreach(string key in _ShapeClassRegistry.Keys)
            {
                if(_ShapeClassRegistry[key] == kind)
                {
                    return key;
                }
            }
            return null; 
        }


        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistry[name]);
        }
        public Shape(Color color)
        {
            _color = color;
        }

        public Shape() : this(Color.White)
        {
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(Key(this.GetType()));
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadForm(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }

    }

}
