// Shape.cs
public class Shape
{
    public string Color { get; set; }

    public Shape(string color)
    {
        Color = color;
    }

    // Virtual method to be overridden by derived classes
    public virtual double GetArea()
    {
        return 0;
    }
}

