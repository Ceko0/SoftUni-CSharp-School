namespace Shapes
{
    public abstract class Shape : IDrawing
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
       
        public virtual string Draw()
        {
            return $"Drawing {GetType().Name}";
        }
    }
}
