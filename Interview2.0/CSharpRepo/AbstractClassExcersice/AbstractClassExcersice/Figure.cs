using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassExcersice
{
    public abstract class Figure
    {
        public double Width, Height, Radius;
        public const float PI = 3.14f;
        public abstract double GetArea();
    }
    public class Rectangle : Figure
    {
        public Rectangle(double width, double height){ this.Width = width; this.Height = height;  }
        public override double GetArea() { return Width * Height; }        
    }
    public class Circle : Figure
    {
        public Circle(double radius) { this.Radius = radius; }
        public override double GetArea() { return PI * Radius * Radius; }
    }
    public class Cone : Figure
    {
        public Cone(double radius, double height) { this.Radius = radius; this.Height = height; }
        public override double GetArea() 
        { 
            return PI * Radius * (Radius + Math.Sqrt(Height * Height + Radius * Radius)); 
        }
    }

    public class TestFigure
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(10.0,20.0);
            Circle circle = new Circle(15.0);
            Cone cone = new Cone(15.0, 5.0);

            Console.WriteLine($"Area of Rectangle :> {rectangle.GetArea()}");
            Console.WriteLine($"Area of Circle :> {circle.GetArea()}");
            Console.WriteLine($"Area of Cone :> {cone.GetArea()}");

            Console.ReadLine();
        }
    }
}
