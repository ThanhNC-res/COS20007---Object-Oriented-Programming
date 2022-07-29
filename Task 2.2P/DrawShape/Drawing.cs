using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this(Color.White) { }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void SelectShapeAt()
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(SplashKit.MousePosition()))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        public List<Shape> SelectedShape
        {
            get
            {
                List<Shape> SelectedShapes = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        SelectedShapes.Add(s);
                    }
                }

                return SelectedShapes;
            }
        }

        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }

        public void Save(String filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(Background);
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            int count;
            Shape s;
            string kind;

            Background = reader.ReadColor();
            count = reader.ReadInteger();
            _shapes.Clear();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();

                    //switch (kind)
                    //{
                    //    case "Rectangle":
                    //        s = new MyRectangle();
                    //        break;
                    //    case "Circle":
                    //        s = new MyCircle();
                    //        break;
                    //    case "Line":
                    //        s = new MyLine();
                    //        break;
                    //    default:
                    //        throw new InvalidDataException("Unkown shape kind: " + kind);
                    //}

                    s = Shape.CreateShape(kind);

                    s.LoadForm(reader);
                    _shapes.Add(s);
                }
            }
            
            finally
            {
                reader.Close();
            }
        }

    }
}
