<Query Kind="Program" />

// Source - https://www.youtube.com/watch?v=2B4Zt4hBG9Y&list=WL&index=6&t=695s
// Functional Style 
// we went from one collection to the next and one more and then to a value 

// In this process, we created garbage variables. 
// The more garbage we create the more we need to collect.

// It is not a big deal if the dataset is small but 
// think if the dataset is large then we might get OutOfMemoryException 

// So before using functional chaining or compositing one or more function
// Think on what type of dataset you would executing it on....
void Main()
{
	Console.WriteLine("--------------------------------");
	printEvenNumbersAggregateIt();
}

public void printEvenNumbersAggregateIt()
{
	var list = new List<int> { 1, 2, 3, 4, 5, 6 };
		
	Console.WriteLine(list.AsEnumerable()
		.Where(l => l % 2 == 0)
		.Select(l => l * 2)
		.Aggregate ((total, number) => total + number));
		
	Console.WriteLine("--------------------------------");
		
	var query1 = list.AsEnumerable();
	Console.WriteLine(query1); // List
	var query2 = query1.Where(x => x % 2 == 0);	
	Console.WriteLine(query2); // IEnumerable 
	var query3 = query2.Select(x => x * 2);	
	Console.WriteLine(query3); // IEnumerable 
	var query4 = query3.Aggregate((total, number)=> total + number); 
	Console.WriteLine(query4); // Value
}
