using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        Square square = new Square("Red", 20);

        Rectangle rectangle = new Rectangle("Blue", 10, 20);

        Circle circle = new Circle("Green", 15);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach(Shape shape in shapes){
            DisplayShapeInformation(shape);
        }
    }

    public static void DisplayShapeInformation(Shape shape){
        Console.WriteLine($"The shape is a {shape.GetType()} of color {shape.GetColor()} and an area of {shape.CalculateArea()}");
    }
}