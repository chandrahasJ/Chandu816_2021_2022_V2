using System;

namespace StructExample
{
    struct MyStruct2
    {
        public int i;
        public MyStruct2(int i) { this.i = i; }
        public void Display() { Console.WriteLine("Method in Structure MyStruct2 : " + i); }
    }
    struct MyStruct3
    {
        public void Display() { Console.WriteLine("Method in Structure MyStruct3"); }
        static void Main(string[] args)
        {
            //If struct has fields declared in it then "new" keyword is mandatory or
            //else we need to intialize the each and every fields explicitly 
            //Type 1 
            MyStruct2 myStruct2;
            //myStruct2.Display();  // Error if you try to access display method directly
                                    // without initializing the fields
                                    // Since while using field in display method it will be unassigned & un-initialized.
            myStruct2.i = 10;       // Fields should be initialized explicity before being used.
            myStruct2.Display(); 

            //Type 2
            MyStruct2 myStruct21 = new MyStruct2(); // Fields will be initialized by default constructor
            myStruct21.Display();

            //Type 3 
            MyStruct2 myStruct22 = new MyStruct2(30); // Fields will be initialized by explicity constructor
            myStruct22.Display();
            Console.WriteLine("---------------------------------------------------");
            //If struct has not fields declared in it then "new" keyword is optional 
            MyStruct3 myStruct3; myStruct3.Display(); //Type 1 
            MyStruct3 myStruct31 = new MyStruct3(); myStruct31.Display(); //Type 2
            Console.ReadLine();
        }
    }
}
