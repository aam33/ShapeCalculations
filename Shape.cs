using System;

public abstract class Shape
{
	public int shapeID;
	public string shapeType;

	public Shape(int id, string type)
	{
		shapeID = id;
		shapeType = type;	
	}

	public string getShapeType()
	{ return shapeType; }

	public int getShapeID()
	{ return shapeID; }

}
