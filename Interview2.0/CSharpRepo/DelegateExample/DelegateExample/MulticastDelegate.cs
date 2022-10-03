using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateExample
{
    public delegate void RectangleDelegate(double Width, double Height);
    public class Rectangle
    {
        public void GetArea(double Width, double Height) 
        { Console.WriteLine($"Area of Rect :> {Width * Height}"); }
        public void GetPerimeter(double Width, double Height)
        { Console.WriteLine($"Area of Rect :> {2 * (Width + Height)}"); }
        public static void Main()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.GetArea(100,50); rectangle.GetPerimeter(100, 50); //Normal 
            Console.WriteLine("====================");
            //instaniting the delegate
            RectangleDelegate rectangleDelegate = rectangle.GetArea;
            // using += make the delegate a multicast delegate
            rectangleDelegate += rectangle.GetPerimeter;
            //Invocation Type 1
            rectangleDelegate(200, 50);
            Console.WriteLine("====================");
            //Invocation Type 2
            rectangleDelegate(200, 50);
            Console.ReadLine();
        }
    }
}
