using Shapes.Models;

namespace Shapes;
public class StartUp
{
    static void Main(string[] args)
    {
        //Circle circle = new(10);
        //Console.WriteLine(circle.CalculateArea());
        //Console.WriteLine(circle.CalculatePerimeter());
        //Console.WriteLine(circle.Draw());

        //Rectangle rectangle = new(4, 4);
        //Console.WriteLine(rectangle.CalculateArea());
        //Console.WriteLine(rectangle.CalculatePerimeter());
        //Console.WriteLine(rectangle.Draw());

        Shape shape = new Circle(10);
        PrintInfo(shape);

        shape = new Rectangle(2, 5);
        PrintInfo(shape);

    }

    private static void PrintInfo(Shape shape)
    {
        Console.WriteLine(shape.CalculateArea());
        Console.WriteLine(shape.CalculatePerimeter());
        Console.WriteLine(shape.Draw());
    }
}

