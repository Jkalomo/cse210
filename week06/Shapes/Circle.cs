// Circle.cs
public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

