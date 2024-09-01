using System;

public class Triangle : Shape
{
    public double centerx;
    public double centery;
    public double sideLength;
    public double orientation;

    public Triangle(int id, string type, double x, double y, double side, double or)
        : base(id, type)
    {
        centerx = x;
        centery = y;
        sideLength = side;
        orientation = or;
    }

    public double calculateTriangleArea()
    {
        return Math.Sqrt(3) / 4 * (sideLength*sideLength);
    }

    public double calculateTrianglePerimeter()
    {
        return 3 * sideLength;
    }

    public double getLength()
    { return sideLength; }

}
