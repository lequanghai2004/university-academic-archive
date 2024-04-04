namespace ShapeDrawer
{
    internal class MyRectangle : Shape
    {
        private int _width;
        private int _height;
        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x; Y = y;
            _width = width;
            _height = height;
        }
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100) { }
        public MyRectangle(StreamReader reader)
        {
            LoadFrom(reader);
        }
        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }
        public override void Draw()
        {
            SplashKit.FillRectangle(_color, X, Y, _width, _height);
        }
        public override bool IsAt(Point2D pt)
        {
            return pt.X > X
                && pt.X < X + _width
                && pt.Y > Y
                && pt.Y < Y + _height;
        }
        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }
    }
}
