using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("green", 2.2);
        Rectangle rectangle = new Rectangle("lime", 6, 7);
        Circle circle = new Circle("chartreuese", 2784);

        List<Shape> shapes = new List<Shape>(){
            square,
            rectangle,
            circle
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}\n");
        }

    }
}