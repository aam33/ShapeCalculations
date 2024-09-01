//Console.WriteLine("Hello, World!");

Console.WriteLine("Example HARD-CODED shapes for testing purposes below:");
Circle circle1 = new Circle(1, "Circle", 1.2, 2.3, 2);
Ellipse ellipse1 = new Ellipse(2, "Ellipse", 1.4, 4.2, 3, 2, 3.452);
Square square1 = new Square(3, "Square", 4.2345, 12.335, 3, 1.2);
Triangle triangle1 = new Triangle(4, "Triangle", 86.8, 278.3, 5, 5.12);
double[] xCoords = { 346.746, 413.75, 309.926, 34.4096, 346.746 };
double[] yCoords = { 51.165, 208.36, 280.286, 297.813, 51.165 };
Polygon polygon1 = new Polygon(5, "Polygon", xCoords, yCoords);
double[] xCoords2 = { 319.06, 468.46, 107.774, 319.06 };
double[] yCoords2 = { 179.485, 446.311, 400.872, 179.485 };
Polygon polygon2 = new Polygon(6, "Polygon", xCoords2, yCoords2);
double[] xCoords3 = { 346.854, 436.13, 499.906, 401.249, 169.881, 5.77454, 2.29248, 27.5634, 67.1746, 346.854 };
double[] yCoords3 = { 11.5733, 210.35, 411.111, 475.019, 485.776, 443.976, 400.069, 142.666, 36.798, 11.5733 };
Polygon polygon3 = new Polygon(7, "Polygon", xCoords3, yCoords3);
//Should appear as invalid (success)
//double[] xCoords4 = { 5, 6 };
//double[] yCoords4 = { 7, 8 };
//Polygon polygon4 = new Polygon(8, "Polygon", xCoords4, yCoords4);

Console.WriteLine("Circle: The radius is " + circle1.getRadius() + " and the area is " + circle1.calculateCircleArea() + " and the circumference is " + circle1.calculateCirclePerimeter());
Console.WriteLine("Ellipse: The larger half axis is " + ellipse1.getRadius1() + " and the smaller half axis is " + ellipse1.getRadius2() + " and the area is " + ellipse1.calculateEllipseArea() + " and the perimeter is about " + ellipse1.calculateEllipsePerimeter());
Console.WriteLine("Square: The length of a side is " + square1.getLength() + " and the area is " + square1.calculateSquareArea() + " and the perimeter is " + square1.calculateSquarePerimeter());
Console.WriteLine("Triangle: The length of a side is " + triangle1.getLength() + " and the area is " + triangle1.calculateTriangleArea() + " and the perimeter is " + triangle1.calculateTrianglePerimeter());
Console.WriteLine("5-sided Polygon: The area is " + polygon1.calculatePolygonArea() + " and the perimeter is " + polygon1.calculatePolygonPerimeter());
Console.WriteLine("4-sided Polygon: The area is " + polygon2.calculatePolygonArea() + " and the perimeter is " + polygon2.calculatePolygonPerimeter());
Console.WriteLine("10-sided Polygon: The area is " + polygon3.calculatePolygonArea() + " and the perimeter is " + polygon3.calculatePolygonPerimeter() + "\n");
// Should fail (success)
//Console.WriteLine("2-sided Polygon: The area is " + polygon4.calculatePolygonArea() + " and the perimeter is " + polygon4.calculatePolygonPerimeter());



string input = "ShapeList2.csv";
string output = "output.csv";

var shapes = CsvProcessor.ReadShapesFromCsv(input);
CsvProcessor.WriteShapesToCsv(output, shapes);

Console.WriteLine("CSV processing complete. View output.csv for output file. For me, this is found at: C:\\Users\\{my-username}\\source\\repos\\ShapeCalculations\\bin\\Debug\\net6.0");