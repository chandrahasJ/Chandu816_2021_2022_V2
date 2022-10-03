using System;
using System.Collections.Generic;
using System.Text;

namespace MethodOverriding
{
    public class Matrix
    {
        int a, b, c, d;
        public Matrix(int a, int b, int c, int d)
        {
            this.a = a; this.b = b; this.c = c; this.d = d;
        }
        //Operator Overloading for + for Matrix objects
        public static Matrix operator +(Matrix obj1, Matrix obj2)
        {
            return new Matrix(obj1.a + obj2.a, obj1.b + obj2.b, obj1.c + obj2.c, obj1.d + obj2.d);
        }
        //Operator Overloading for - for Matrix objects
        public static Matrix operator -(Matrix obj1, Matrix obj2)
        {
            return new Matrix(obj1.a - obj2.a, obj1.b - obj2.b, obj1.c - obj2.c, obj1.d - obj2.d);
        }
        //Method overriding of ToString method 
        public override string ToString()
        {
            return $"{a}\t{b}\n{c}\t{d}\n";
        }
    }
    public class TextMatrix
    {
        static void Main()
        {
            Matrix m1 = new Matrix(20,10,5,0);
            Matrix m2 = new Matrix(10,20,30,40);
            Matrix m3 = m1 + m2;
            Matrix m4 = m1 - m2;

            Console.WriteLine(m1); Console.WriteLine(m2); Console.WriteLine(m3); Console.WriteLine(m4);
            Console.ReadLine();
        }
    }
}
