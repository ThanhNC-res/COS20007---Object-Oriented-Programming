using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {

        public enum ShapeKind 
        { 
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Shape.RegisterShape("Rectangle", typeof(MyRectangle));
            Shape.RegisterShape("Circle", typeof(MyCircle));
            Shape.RegisterShape("Line", typeof(MyLine));

            new Window("Shape Drawer", 800, 600);
            Drawing MyDraw = new Drawing { Background = Color.White };
            SplashKit.ClearScreen(MyDraw.Background);
            ShapeKind Kindtoadd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(MyDraw.Background);
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        MyDraw.Load("D:/IT MAJOR/Object-Oriented Programming/Assignment/Task 2.2P/DrawShape/bin/Debug/netcoreapp5.0/TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error Loading File: {0}", e.Message);
                    }
                }
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    try
                    {
                        MyDraw.Save("TestDrawing.txt");
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine("Error Saving File: {0}", e.Message);
                    }
                }
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    Kindtoadd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    Kindtoadd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    Kindtoadd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    if (Kindtoadd == ShapeKind.Circle)
                    {
                        newShape = new MyCircle();

                    }
                    else if (Kindtoadd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();
                    }
                    else
                    {
                        Random rnd = new Random();
                        float endx, endy;
                        int x_axis;
                        int y_axis;
                        MyLine newLine = new MyLine();
                        x_axis = rnd.Next(-400, 400);
                        y_axis = rnd.Next(-300, 300);
                        endx = SplashKit.MouseX() + x_axis;
                        endy = SplashKit.MouseY() + y_axis;
                        newLine.Endx = endx;
                        newLine.Endy = endy;
                        newShape = newLine;
                    }
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    MyDraw.AddShape(newShape);

                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    MyDraw.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    MyDraw.SelectShapeAt();
                }
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in MyDraw.SelectedShape)
                    {
                        MyDraw.RemoveShape(s);
                    }
                }


                MyDraw.Draw();
                

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));

        }
    }
}