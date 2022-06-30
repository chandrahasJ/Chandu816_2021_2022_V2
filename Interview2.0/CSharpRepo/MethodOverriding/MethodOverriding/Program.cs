using System;

namespace MethodOverriding
{
    class ParentLoad
    {
        public void Show() { Console.WriteLine("Parent Show Method"); }
        //Overridable
        public virtual void Test() { Console.WriteLine("Parent Test Method"); }
    }

    class ChildLoad : ParentLoad
    {
        //OverLoading
        public void Show(int i) { Console.WriteLine("Child Show Method"); }
        //Overriding
        public override void Test() { Console.WriteLine("Child Test Method"); }

        public new void Show() { Console.WriteLine("Child Show Method"); }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ChildLoad childLoad = new ChildLoad();
            childLoad.Show();
            childLoad.Show(10);

            childLoad.Test(); //Child method will be called since it is overridden in child class

            Console.ReadLine();
        }
    }
}
