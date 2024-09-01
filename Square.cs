using System;

public class Square : Shape
{
    public double centerx;
    public double centery;
    public double sideLength;
    public double orientation;

    public Square(int id, string type, double x, double y, double side, double or)
        : base(id, type)
    {
        centerx = x;
        centery = y;
        sideLength = side;
        orientation = or;
    }

    public double calculateSquareArea()
    {
        return sideLength * sideLength;
    }

    public double calculateSquarePerimeter()
    {
        return 4 * sideLength;
    }

    public double getLength()
    { return sideLength; }

}
