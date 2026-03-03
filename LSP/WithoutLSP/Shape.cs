using System;

namespace SOLIDPrinciples.LSP.WithoutLSP
{
    // This example violates the Liskov Substitution Principle
    // The Square class breaks the contract of Rectangle
    
    public class Rectangle
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

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

    // Square inherits from Rectangle but violates LSP by changing behavior
    // Setting Width also changes Height and vice versa, breaking expected behavior
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }

        // Overriding width to also set height, breaking expected behavior of Rectangle
        public override double Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
                base.Height = value; // This violates LSP - changes behavior
            }
        }

        // Overriding height to also set width, breaking expected behavior of Rectangle
        public override double Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                base.Width = value; // This violates LSP - changes behavior
            }
        }
    }

    public class LSPDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n=== Without LSP Example ===\n");
            
            // This test method demonstrates the LSP violation
            Console.WriteLine("Testing rectangle:");
            Rectangle rectangle = new Rectangle(5, 10);
            TestRectangle(rectangle);
            
            Console.WriteLine("\nTesting square:");
            Rectangle square = new Square(4);
            TestRectangle(square); // This will give unexpected results
        }

        // This method expects a Rectangle's contract to be honored
        private static void TestRectangle(Rectangle rectangle)
        {
            rectangle.Width = 5;
            rectangle.Height = 10;
            
            // For a rectangle, area should be 5 * 10 = 50
            // For a square, area will incorrectly be 10 * 10 = 100 (LSP violation)
            Console.WriteLine($"Width: {rectangle.Width}, Height: {rectangle.Height}");
            Console.WriteLine($"Expected area: 50, Actual area: {rectangle.CalculateArea()}");
        }
    }
}
