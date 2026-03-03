using System;

namespace SOLIDPrinciples.LSP.WithLSP
{
    // This example follows the Liskov Substitution Principle
    // We use a common abstraction (IShape) for both Square and Rectangle
    
    // Common abstraction for all shapes
    public interface IShape
    {
        double CalculateArea();
    }

    // Rectangle implementation
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    // Square as its own implementation of IShape (not inheriting from Rectangle)
    public class Square : IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double CalculateArea()
        {
            return Side * Side;
        }
    }

    public class LSPDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n=== With LSP Example ===\n");
            
            // Test the shapes separately, respecting their own contracts
            Console.WriteLine("Testing rectangle:");
            var rectangle = new Rectangle(5, 10);
            rectangle.Width = 5;
            rectangle.Height = 10;
            Console.WriteLine($"Width: {rectangle.Width}, Height: {rectangle.Height}");
            Console.WriteLine($"Area: {rectangle.CalculateArea()}");
            
            Console.WriteLine("\nTesting square:");
            var square = new Square(5);
            square.Side = 5;
            Console.WriteLine($"Side: {square.Side}");
            Console.WriteLine($"Area: {square.CalculateArea()}");
            
            // Test polymorphic behavior using the common interface
            Console.WriteLine("\nTesting polymorphic behavior:");
            IShape rectangleShape = new Rectangle(4, 6);
            IShape squareShape = new Square(4);
            
            Console.WriteLine($"Rectangle area: {rectangleShape.CalculateArea()}");
            Console.WriteLine($"Square area: {squareShape.CalculateArea()}");
        }
    }
}
