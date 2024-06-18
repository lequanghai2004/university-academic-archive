namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;
        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }
        public MyLine(Color color, float startX, float startY) 
            : this(color, startX, startY, startX, startY) { }
        public MyLine(StreamReader reader)
        {
            LoadFrom(reader);
        }
        public override void Draw()
        {
            Point2D startPt = new Point2D();
            startPt.X = X;
            startPt.Y = Y;

            Point2D endPt = new Point2D();
            endPt.X = _endX;
            endPt.Y = _endY;
            
            new MyCircle(Color.BlueViolet, X, Y, 2).Draw();
            new MyCircle(Color.BlueViolet, _endX, _endY, 2).Draw();
            SplashKit.DrawLine(Color, startPt, endPt);
        }
        public float EndX { set { _endX = value; } }
        public float EndY { set { _endY = value; } }
        public override void DrawOutline()
        {
            Point2D startPt1 = new Point2D();
            startPt1.X = X + 2.5;
            startPt1.Y = Y + 2.5;

            Point2D endPt1 = new Point2D();
            endPt1.X = _endX + 2.5;
            endPt1.Y = _endY + 2.5;

            Point2D startPt2 = new Point2D();
            startPt2.X = X + 2.5;
            startPt2.Y = Y + 2.5;

            Point2D endPt2 = new Point2D();
            endPt2.X = _endX + 2.5;
            endPt2.Y = _endY + 2.5;

            Color color = SplashKit.RandomColor();
            SplashKit.DrawLine(color, startPt1, endPt1);
            SplashKit.DrawLine(color, startPt2, endPt2);
        }
        public override bool IsAt(Point2D pt)
        {
            float vecX = Y - _endY;
            float vecY = _endX - X;
            return vecX * (pt.X - X) + vecY * (pt.Y - Y) < 1500
               && vecX * (pt.X - X) + vecY * (pt.Y - Y) > - 1500;
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endX);
            writer.WriteLine(_endY);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _endX = reader.ReadSingle();
            _endY = reader.ReadSingle();
        }
    }
}
