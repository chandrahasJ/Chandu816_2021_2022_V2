using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassExcersice
{
    abstract class AbstractParent
    {
        public void add(int x, int y) { Console.WriteLine(x + y); }
        public void subtract(int x, int y) { Console.WriteLine(x - y); }
        public abstract void multiple(int x, int y);
        public abstract void divide(int x, int y);
        public static void show(string msg) { Console.WriteLine(msg); }
    }
    class Child : AbstractParent
    {
        public override void multiple(int x, int y) { Console.WriteLine(x * y); }
        public override void divide(int x, int y) { Console.WriteLine(x / y); }
        public void ParentClassWontBeAbleToCallMe() { Console.WriteLine("Pure Child Method"); }
        static void Main(string[] args)
        {
            AbstractParent.show("Test"); //Static Members can be called but instance of abstract class can't be created.
            Child child = new Child(); //Instance of Child class 
            child.add(1, 2); child.subtract(1, 2); child.multiple(1, 2); child.divide(2, 2); child.ParentClassWontBeAbleToCallMe();
            Console.WriteLine("------------------------------------------------------------");
            //abstractParent is reference of Abstract class using the child class instance
            AbstractParent abstractParent = child;
            //Parent class reference can call child classes overridden methods but not purely defined methods
            abstractParent.add(1, 2); abstractParent.subtract(1, 2); abstractParent.multiple(1, 2); abstractParent.divide(2, 2);
            //abstractParent.ParentClassWontBeAbleToCallMe(); //Error 
            Console.ReadLine();
        }
    }
}
