<Query Kind="Program" />

void Main()
{
	printEvenNumbersImperativeStyle();
	Console.WriteLine("----------------");
	printEvenNumbersDeclartiveStyle();
}

public void printEvenNumbersDeclartiveStyle()
{
	var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	list.AsQueryable()
		.Where(x => x % 2 == 0) // Higher Order Function
		.Select(x => x * 2) // Higher Order Function
		.ToList() // Conversion to list 
		.ForEach(Console.WriteLine);				
}


public void printEvenNumbersImperativeStyle()
{
	var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	 for (int i = 0; i < list.Count; i++)
	{
		if(list[i] % 2 ==0){
			Console.WriteLine(list[i] * 2);
		}
	}
}