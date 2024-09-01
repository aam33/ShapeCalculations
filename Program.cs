//Console.WriteLine("Hello, World!");

string input = "ShapeList2.csv";
string output = "output.csv";

var shapes = CsvProcessor.ReadShapesFromCsv(input);
CsvProcessor.WriteShapesToCsv(output, shapes);

Console.WriteLine("CSV processing complete. View output.csv for output file. For me, this is found at: C:\\Users\\{my-username}\\source\\repos\\ShapeCalculations\\bin\\Debug\\net6.0");