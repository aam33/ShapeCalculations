using System;

public class Polygon : Shape
{
    private double[] x;
    private double[] y;
    private int numPoints;

    public Polygon(int id, string type, double[] xCoords, double[] yCoords)
        : base(id, type)
    {
        if (xCoords.Length != yCoords.Length || xCoords.Length < 3)
            throw new ArgumentException("Invalid polygon coordinates");

        int actualPoints = 0;
        for (int i = 0; i < xCoords.Length; i++)
        {
            if (xCoords[i] != 0 || yCoords[i] != 0)
            {
                actualPoints++;
            }
        }

        x = new double[actualPoints];
        y = new double[actualPoints];

        for (int i = 0; i < actualPoints; i++)
        {
            x[i] = xCoords[i];
            y[i] = yCoords[i];
        }
        numPoints = actualPoints;

        /* HERE FOR TESTING PURPOSES; NOW COMMENTED OUT:
        Console.WriteLine("Polygon ID: " + id);
        for (int i = 0; i < numPoints; i++)
        {
            Console.WriteLine($"Point {i + 1}: ({x[i]}, {y[i]})");
        }
        Console.WriteLine("Calculated Perimeter: " + calculatePolygonPerimeter());*/
    }

    public double calculatePolygonArea()
    {
        double area = 0;

        for (int i = 0; i < numPoints - 1; i++)
        {
            area += x[i] * y[i + 1] - y[i] * x[i + 1];
        }

        // Add the last term that wraps around
        area += x[numPoints - 1] * y[0] - y[numPoints - 1] * x[0];

        return Math.Abs(area / 2.0);
    }

    public double calculatePolygonPerimeter()
    {
        double perimeter = 0;

        for (int i = 0; i < numPoints - 1; i++)
        {
            // uses distance formula
            perimeter += Math.Sqrt(Math.Pow(x[i + 1] - x[i], 2) + Math.Pow(y[i + 1] - y[i], 2));
        }

        // Add the last side that wraps around
        perimeter += Math.Sqrt(Math.Pow(x[0] - x[numPoints - 1], 2) + Math.Pow(y[0] - y[numPoints - 1], 2));

        return perimeter;
    }

}
