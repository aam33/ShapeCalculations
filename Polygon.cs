﻿using System;

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

        x = xCoords;
        y = yCoords;
        numPoints = x.Length;
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
