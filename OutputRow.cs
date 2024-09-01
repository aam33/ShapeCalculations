using System;

public class OutputRow
{
    public int shapeID;
    public string shapeType;
    public double shapeArea;
    public double shapePerimeter;

    public OutputRow(int id, string type, double area, double perimeter)
    {
        shapeID = id;
        shapeType = type;
        shapeArea = area;
        shapePerimeter = perimeter;
    }

    public string getShapeType()
    { return shapeType; }

    public int getShapeID()
    { return shapeID; }

    public double getShapeArea()
    { return shapeArea; }

    public double getShapePerimeter()
    { return shapePerimeter; }

    public string GetDataAsCsv()
    { return $"{shapeID},{shapeArea},{shapePerimeter}"; }
}
