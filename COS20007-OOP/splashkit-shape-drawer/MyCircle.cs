namespace ShapeDrawer
{
    internal class MyCircle : Shape
    {
        private int  _radius;
        public MyCircle(Color color, float x, float y, int radius) : base(color)
        {
            X = x; Y = y;
            _radius = radius;
        }
        public MyCircle() : this(Color.Blue, 100, 100, 50) { }
        public MyCircle(StreamReader reader)
        {
            LoadFrom(reader);
        }
        public int Radius { get { return _radius; } set { _radius = value; } }
        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius+2);
        }
        public override bool IsAt(Point2D pt)
        {
            return _radius >= Math.Sqrt(
                Math.Pow(X - SplashKit.MouseX(), 2) +   
                Math.Pow(Y - SplashKit.MouseY(), 2));
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }
    }
}
