using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeDrawer;
using SplashKitSDK;

namespace DrawingShape
{
    public class Program
    {
        private const string Filename = "C:\\Users\\tranp\\OneDrive\\Máy tính\\save.txt";

        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {

            Drawing drawShape = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Rectangle;

            new Window("Drawing Shape", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                //Start
                //Use this to draw shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle ShapeDrawn = new MyRectangle();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawShape.AddShape(ShapeDrawn);

                    }
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle ShapeDrawn = new MyCircle();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawShape.AddShape(ShapeDrawn);
                    }
                    if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine ShapeDrawn = new MyLine();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawShape.AddShape(ShapeDrawn);
                    }

                    

                }

               

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawShape.SelectShapesAt(SplashKit.MousePosition());
                   
                }

                

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                   
                    foreach (Shape s in drawShape.SelectedShapes)
                    {
                        drawShape.RemoveShape(s);
                    }
                }


                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawShape.Background = SplashKit.RandomRGBColor(255);
                   
                }

 

                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    drawShape.Save(Filename);
                }

                

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawShape.Load(Filename);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                

                drawShape.Draw();

                SplashKit.RefreshScreen();

            }
            while (!SplashKit.WindowCloseRequested("Drawing Shape"));
        }
    }

}

