<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	ParameterizedMethodTPLEg();
}

public static int GetLength(int upperBound)
{
	string str = "";
	for (int i = 0; i <= upperBound; i++)
		str += i;
	return str.Length;
}

public static void ParameterizedMethodTPLEg(){
	Task<int> task = new Task<int>(() => GetLength(10));
	task.Start();
	
	Task<int> taskFactory = Task<int>.Factory.StartNew (() => GetLength(10));

	$"Result :> {task.Result}".Dump();
	$"Result Factory :> {taskFactory.Result}".Dump();
}

// You can define other methods, fields, classes and namespaces here