using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;

public class CsvProcessor
{

    public static List<OutputRow> ReadShapesFromCsv(string filepath)
    {
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
                        double[] xCoords = new double[10];
                        double[] yCoords = new double[10];
                        int x = 3;
                        int y = 5;
                        // index
                        int i = 0;
                        while (values[x] != "" && i < 10 && x < 39)
                        {
                            double tempx = double.Parse(values[x]);
                            xCoords[i] = tempx;
                            double tempy = double.Parse(values[y]);
                            yCoords[i] = tempy;
                            x += 4;
                            y += 4;
                            i++;
                        }
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
        using (var writer = new StreamWriter(filepath))
        {
            foreach (var row in outputRows)
            {
                writer.WriteLine(row.GetDataAsCsv());
            }
        }
    }
}