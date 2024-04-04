global using SplashKitSDK;
using System;

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
            ShapeKind kindToAdd = ShapeKind.Circle;

            Drawing drawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);
            Shape? shape = null;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                /// Mouse event handler
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Color color = Color.Green;
                    float x = SplashKit.MouseX();
                    float y = SplashKit.MouseY();

                    switch (kindToAdd)
                    {
                        case ShapeKind.Rectangle:
                            shape = new MyRectangle(color, x, y, 100, 100); break;
                        case ShapeKind.Circle:
                            shape = new MyCircle(color, x, y, 50); break;
                        case ShapeKind.Line:
                            if (shape is MyLine)
                            {
                                (shape as MyLine).EndX = SplashKit.MouseX();
                                (shape as MyLine).EndY = SplashKit.MouseY();
                                shape = null;
                            }
                            else shape = new MyLine(color, x, y); break;
                    }
                    if (shape != null) drawing.AddShape(shape);
                }
                else if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapeAt(SplashKit.MousePosition());
                }
                /// line drawing
                if (shape is MyLine)
                {
                    (shape as MyLine).EndX = SplashKit.MouseX();
                    (shape as MyLine).EndY = SplashKit.MouseY();
                }
                /// Keyboard event handler
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }
                else if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    drawing.RemoveShape();
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                else if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.SaveToFile("D:\\OOP\\ShapeDrawer\\TestDrawing.txt");
                }
                else if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("D:\\OOP\\ShapeDrawer\\TestDrawg.txt");
                    }
                    catch(Exception e)
                    {
                        Console.Error.WriteLine("Load file error: " + e.Message);
                    }
                }

                drawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
