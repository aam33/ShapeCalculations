using System;

public class Circle : Shape
{
	public double centerx;
	public double centery;
	public double radius;

	public Circle(int id, string type, double x, double y, double r)
        : base(id, type)
    {
		centerx = x;
		centery = y;
		radius = r;
	}

	public double calculateCircleArea()
	{
		return Math.PI * radius * radius;
	}

	public double calculateCirclePerimeter()
	{
		return 2 * Math.PI * radius;
	}

	public double getRadius()
	{ return radius; }

}
