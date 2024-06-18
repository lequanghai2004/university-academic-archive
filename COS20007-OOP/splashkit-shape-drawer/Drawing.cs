using SplashKitSDK;
using System.ComponentModel.Design;

namespace ShapeDrawer
{
    public class Drawing
    {
        private List<Shape> _shapes = new List<Shape>();
        private Color _background;
        public Drawing(Color background)
        {
            _background = background;
        }
        public Drawing() : this(Color.White) { }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach(Shape shape in _shapes)
                {
                    if(shape.Selected) result.Add(shape);
                }
                return result;
            }
        }
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }
        public Color Background
        {
            get { return  _background; }
            set { _background = value; }
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape shape in SelectedShapes) shape.DrawOutline();
            foreach(Shape shape in _shapes) shape.Draw();
        }
        public void SelectShapeAt(Point2D pt)
        {
            foreach(Shape shape in _shapes)
            {
                shape.Selected = shape.IsAt(pt);
            }
        }
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        public void RemoveShape()
        {
            foreach (Shape shape in SelectedShapes) _shapes.Remove(shape);
        }
        public void SaveToFile(string file)
        {
            StreamWriter writer = new StreamWriter(file);
            try
            {
                writer.WriteColor(_background);
                writer.WriteLine(_shapes.Count);

                foreach (Shape shape in _shapes)
                {
                    shape.SaveTo(writer);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
            }
            finally
            {
                writer.Close();
            }
        }
        public void Load(string file)
        {
            StreamReader reader = new StreamReader(file);
            try
            {
                _background = reader.ReadColor();
                int count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    Shape? shape = null;
                    string? kindOfShape = reader.ReadLine();
                    switch (kindOfShape)
                    {
                        case "Rectangle":
                            shape = new MyRectangle(reader);
                            break;
                        case "Circle":
                            shape = new MyCircle(reader);
                            break;
                        case "Line":
                            shape = new MyLine(reader);
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kindOfShape);
                    }
                    _shapes.Add(shape);
                }
            } 
            catch(Exception e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}