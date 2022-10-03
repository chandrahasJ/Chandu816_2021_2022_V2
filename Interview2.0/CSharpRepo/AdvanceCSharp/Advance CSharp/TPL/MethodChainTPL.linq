<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// TPL chaining is achieve by using ContinueWith()
	// Method Signature should be same for using ContinueWith	
	Task taskChain = new Task(() => { Multiple(5,5);});
	taskChain.ContinueWith(prevoius => NewLine());
	taskChain.ContinueWith(prevoius => MultipleReverse(5,5));
	taskChain.Start();	
	
	Task taskFactoryChain = Task.Factory.StartNew (() => NewLine())
								.ContinueWith(f => Multiple(2,2))
								.ContinueWith(f => NewLine())
								.ContinueWith(f => MultipleReverse(2,1));
}

public static void Multiple(int mutliplier, int upperBound){
	for (int i = 1; i <= upperBound; i++)
		$"{mutliplier} * {i} = {mutliplier * i}".Dump();
}

public static void NewLine(){
	$"Start new".Dump();
}

public static void MultipleReverse(int mutliplier, int upperBound)
{
	for (int i = upperBound; i >= 1; i--)
		$"{mutliplier} * {i} = {mutliplier * i}".Dump();
}

// You can define other methods, fields, classes and namespaces here