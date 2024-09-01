using System;

public class Ellipse : Shape
{
    public double centerx;
    public double centery;
    public double largerHalfAxis;
    public double smallerHalfAxis;
    public double orientation;

    public Ellipse(int id, string type, double x, double y, double r1, double r2, double or)
        : base(id, type)
    {
        centerx = x;
        centery = y;
        largerHalfAxis = r1;
        smallerHalfAxis = r2;
        orientation = or;
    }

    public double calculateEllipseArea()
    {
        return Math.PI * largerHalfAxis * smallerHalfAxis;
    }

    // NOTE: Use "approximation 2" from this website: https://www.mathsisfun.com/geometry/ellipse-perimeter.html
    public double calculateEllipsePerimeter()
    {
        return Math.PI * (3*(largerHalfAxis+smallerHalfAxis) - Math.Sqrt((3*largerHalfAxis+smallerHalfAxis)*(largerHalfAxis+3*smallerHalfAxis)));
    }

    public double getRadius1()
    { return largerHalfAxis; }

    public double getRadius2()
    { return smallerHalfAxis; }

}
