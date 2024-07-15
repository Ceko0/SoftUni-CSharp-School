namespace ClassBoxData
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            if (length <= 0) throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            if (width <= 0) throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            if (height <= 0) throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length { get; }
        public double Width { get; }
        public double Height { get; }

        public double SurfaceArea() => (Length * Height + Width * Height + Width * Length) * 2;

        public double LateralSurfaceArea() => (Length * Height + Width * Height) * 2;

        public double Volume() => Length * Height * Width;

    }
}
