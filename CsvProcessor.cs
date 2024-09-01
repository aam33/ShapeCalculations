using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;

public class CsvProcessor
{

    public static List<OutputRow> ReadShapesFromCsv(string filepath)
    {
        Console.WriteLine("Reading from input CSV file...");
        var shapesWithCalculations = new List<OutputRow>();

        using (var reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split(',');

                int id = int.Parse(values[0]);
                string type = values[1];

                switch (type)
                {
                    case "Circle":
                        double ccenterx = double.Parse(values[3]);
                        double ccentery = double.Parse(values[5]);
                        double radius = double.Parse(values[7]);
                        //Console.WriteLine("Circle radius: " + radius);
                        Circle circle = new Circle(id, type, ccenterx, ccentery, radius);
                        double carea = circle.calculateCircleArea();
                        //Console.WriteLine("Circle area: " + carea);
                        double cperimeter = circle.calculateCirclePerimeter();
                        //Console.WriteLine("Circle perimeter: " + cperimeter);
                        shapesWithCalculations.Add(new OutputRow(id, type, carea, cperimeter));
                        break;
                    // should add all circles to the list, along with their areas and perimeters
                    case "Ellipse":
                        double ecenterx = double.Parse(values[3]);
                        double ecentery = double.Parse(values[5]);
                        double lha = double.Parse(values[7]);
                        double sha = double.Parse(values[9]);
                        double eorient = double.Parse(values[11]);
                        Ellipse ellipse = new Ellipse(id, type, ecenterx, ecentery, lha, sha, eorient);
                        double earea = ellipse.calculateEllipseArea();
                        //Console.WriteLine("Ellipse area: " + earea);
                        double eperimeter = ellipse.calculateEllipsePerimeter();
                        //Console.WriteLine("Ellipse perimeter: " + eperimeter);
                        shapesWithCalculations.Add(new OutputRow(id, type, earea, eperimeter));
                        break;
                    // should add all ellipses to the list, along with their areas and perimeters
                    case "Square":
                        double scenterx = double.Parse(values[3]);
                        double scentery = double.Parse(values[5]);
                        double sside = double.Parse(values[7]);
                        //Console.WriteLine("Square side length: " + sside);
                        double sorient = double.Parse(values[9]);
                        Square square = new Square(id, type, scenterx, scentery, sside, sorient);
                        double sarea = square.calculateSquareArea();
                        //Console.WriteLine("Square area: " + sarea);
                        double sperimeter = square.calculateSquarePerimeter();
                        //Console.WriteLine("Square perimeter: " + sperimeter);
                        shapesWithCalculations.Add(new OutputRow(id, type, sarea, sperimeter));
                        break;
                    // should add all squares to the list, along with their areas and perimeters
                    case "Equilateral Triangle":
                        double tcenterx = double.Parse(values[3]);
                        double tcentery = double.Parse(values[5]);
                        double tside = double.Parse(values[7]);
                        //Console.WriteLine("Triangle side length: " + tside);
                        double torient = double.Parse(values[9]);
                        Triangle triangle = new Triangle(id, type, tcenterx, tcentery, tside, torient);
                        double tarea = triangle.calculateTriangleArea();
                        //Console.WriteLine("Triangle area: " + tarea);
                        double tperimeter = triangle.calculateTrianglePerimeter();
                        //Console.WriteLine("Triangle perimeter: " + tperimeter);
                        shapesWithCalculations.Add(new OutputRow(id, type, tarea, tperimeter));
                        break;
                    // should add all triangles to the list, along with their areas and perimeters
                    case "Polygon":
                        List<double> xCoord = new List<double>();
                        List<double> yCoord = new List<double>();

                        for (int i = 3; i < values.Length - 1; i+=4)
                        {
                            if (!string.IsNullOrEmpty(values[i]) && !string.IsNullOrEmpty(values[i+2]))
                            {
                                xCoord.Add(double.Parse(values[i]));
                                yCoord.Add(double.Parse(values[i + 2]));
                            }
                        }

                        double[] xCoords = xCoord.ToArray();
                        double[] yCoords = yCoord.ToArray();
                    
                        Polygon polygon = new Polygon(id, type, xCoords, yCoords);
                        double parea = polygon.calculatePolygonArea();
                        //Console.WriteLine("Polygon area: " + parea);
                        double pperimeter = polygon.calculatePolygonPerimeter();
                        //Console.WriteLine("Polygon perimeter: " + pperimeter);
                        shapesWithCalculations.Add(new OutputRow(id, type, parea, pperimeter));
                        break;
                }
            }
        }

        return shapesWithCalculations;
    }

    public static void WriteShapesToCsv(string filepath, List<OutputRow> outputRows)
    {
        Console.WriteLine("Writing to new CSV file...");
        using (var writer = new StreamWriter(filepath))
        {
            foreach (var row in outputRows)
            {
                writer.WriteLine(row.GetDataAsCsv());
            }
        }
    }
}