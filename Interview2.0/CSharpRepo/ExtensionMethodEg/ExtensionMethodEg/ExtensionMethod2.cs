using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodEg
{
	class Program2
	{
		public void Test1() { Console.WriteLine("Test Method"); }
	}

	static class ExtendedProgram2
	{
		//1 Binding Parameter & 1 Formal Parameter = 2 Parameters defined  
		//Defined with "n" parameters
		public static void ExtendedTest2(this Program2 p, int i)
		{ Console.WriteLine($"Extended Test Method :> {i}"); }
	}
	public class TestProgram2
	{
		public static void Main()
		{
			Program2 p = new Program2();
			p.Test1();
			//Extenstion method called via instance variable
			//Calling Extension method with only formal parameter
			//Binding Parameter will be excluded while calling the Ext. Method
			//Called with only "n-1" parameter
			p.ExtendedTest2(10); 
		}
	}


	static class ExtendedProgram3
	{
		//Extend Factorial to Integer Struct 
		public static long Factorial(this Int32 value)
		{
			return (value == 0 || value == 1 ? 1 : (value == 2 ? 2 : value * Factorial(value - 1)));
		}
	}

	public class TestProgram3
	{
		public static void Main()
		{
			//Integer is a struct 
			int number = 5;
			Console.WriteLine($"Factorial of {number} is {number.Factorial()}");

			number = 10;
			Console.WriteLine($"Factorial of {number} is {number.Factorial()}");

			Console.ReadLine();
		}
	}

	static class ExtendedProgram4
	{
		//Extending functionality to a sealed class
		public static string ToProperCase(this string oldString)
        {
			if (oldString.Trim().Length == 0) return oldString;
			string newString = null;
			oldString = oldString.ToLower();
            foreach (string str in oldString.Split(' '))
            {
				if (str.Trim() == "") continue;
				char[] cArray = str.ToCharArray();
				cArray[0] = Char.ToUpper(cArray[0]);
				if (newString == null)
					newString = new String(cArray);
				else
					newString += $" {new String(cArray)}";
			}
			return newString;
        }
	}

	public class TestProgram4
	{
		public static void Main()
		{
			//string is a sealed class
			string value = "hi, i am chandrahas pOojari.";
			Console.WriteLine(value.ToProperCase());
			value = "hi,  i am chandrahas pOojari. ";
			Console.WriteLine(value.ToProperCase());
			Console.ReadLine();
		}
	}
}
