using System;

namespace GenericExample
{
    public interface IDummyInterface { }
    public class ClassCharacter { }
    public class ClassOne { public ClassOne() { } }
    public class ClassTwo : ClassCharacter { public ClassTwo() { } }
    public class ClassThree : IDummyInterface { public ClassThree() { } }
    class GenericConstraintExample
    {     
        public static T ProduceObjectForClass<T>()  where T : class, new() { return new T(); }         
        public T ProduceOForInheritC<T>() where T : ClassCharacter, new() { return new T(); }
        public T ProduceObjectForInterFace<T>() where T : IDummyInterface, new() { return new T(); }
        public T Add<T>(T a, T b) where T:struct{ dynamic d1 = a; dynamic d2 = b;  return d1 + d2; }
        public static T ProducDefault<T>() where T : class { T returnVal = default(T); return returnVal; }         
        public static void Main()
        {
            GenericConstraintExample genericConstraintExample = new GenericConstraintExample();
            //Since Class Two is inherited with ClassCharacter & also has a parameterless constructor
            ClassTwo classTwo = genericConstraintExample.ProduceOForInheritC<ClassTwo>();
            Console.WriteLine("Object Created :> " +classTwo);
            //Since ClassThree has implemented IDummyInterface & contains parameterless contructor
            ClassThree classThree = genericConstraintExample.ProduceObjectForInterFace<ClassThree>();
            Console.WriteLine("Object Created :> " + classThree);
            //Since ClassOne is User Defined Type i.e. class & contains Parameterless constructor
            ClassOne classOne = ProduceObjectForClass<ClassOne>();
            Console.WriteLine("Object Created :> " + classOne);
            //Since we will be using value type float it will comply with the constraint.
            Console.WriteLine("Add :> float value :> "+genericConstraintExample.Add<float>(5.25f,1.25f));
            Console.WriteLine("Object will not be created."+ ProducDefault<ClassOne>());
        }
        //public T ProduceDummy<T>() where T : ClassCharacter, ClassOne, new() { return new T(); }
    }
}
