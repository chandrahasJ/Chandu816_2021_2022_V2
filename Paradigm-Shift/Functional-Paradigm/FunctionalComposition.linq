<Query Kind="Program" />

// For Future @me - if he comes here - go to this post you idiot lazy bum 
//   - https://stackoverflow.com/questions/5264060/does-c-sharp-support-function-composition


// Functional Style is using functional pipeline 
// i.e. compositing two function into one and providing the output
// We basically chain the functions together to get the desire output in functional style

public static class Extensions
{
	public static Func<T, TReturn2> Compose<T, TReturn1, TReturn2>(this Func<TReturn1, TReturn2> func1, 
																		Func<T, TReturn1> func2)
	{
		return x => func1(func2(x));
	}
}

public static void print(int number, string message, Func<int,int> func){
	Console.WriteLine(number + " " + message + " " + func(number));
}

void Main()
{
	Func<int, int> increment = number => number + 1;
	Func<int, int> doubleIt = number => number * 2;
	Func<int, int> chainedDelegate = increment.Compose(doubleIt);
	
	print(5, nameof(increment), increment);
	print(5, nameof(doubleIt), doubleIt);
	
	// So if we want to increment and double it in one go 
	// we cannot do it as print will only allow one Func as parameter
	// We need to chain the two functions.
	// So now in C# we don't have andThen function 
	// so we chained both delegate with Compose Extension
	print(5, nameof(increment) + " and " + nameof(doubleIt) +" " , chainedDelegate);		
}




// You can define other methods, fields, classes and namespaces here