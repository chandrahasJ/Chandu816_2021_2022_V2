<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	ValueReturningTask();
}

public void ValueReturningTask(){
	Task<int> taskInt = new Task<int>(GetLength);
	taskInt.Start();
	
	// To Capture the result we need to use Task.Result
	int resultInt = taskInt.Result;
	
	Task<string> taskString = new Task<string>(GetMessage);
	Task<string> taskViaFactory = Task.Factory.StartNew (() => GetMessage());
	taskString.Start();

	// To Capture the result we need to use Task.Result
	string resultString = taskString.Result;

	$"Result for Int :>  {resultInt}".Dump();
	$"Result for String :> {resultString}".Dump();
	$"Result for TaskFactory :> {taskViaFactory.Result}".Dump();
}

public static int GetLength(){
	
	string str = "";
	for (int i = 0; i <= 100000; i++)	
	 	str += i;
	return str.Length;
}

public static string GetMessage(){
	return "Some Data";
}

// You can define other methods, fields, classes and namespaces here