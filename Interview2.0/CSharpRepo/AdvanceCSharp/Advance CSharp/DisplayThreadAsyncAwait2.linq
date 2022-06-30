<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	// Part 1
	Thread.CurrentThread.ManagedThreadId.Dump("1");
	var client = new HttpClient();
	Thread.CurrentThread.ManagedThreadId.Dump("2");
	var task = client.GetStringAsync(@"http:\\www.google.com");
	Thread.CurrentThread.ManagedThreadId.Dump("3");
	var a = 0;
	for (int i = 0; i < 100_000_000; i++)
	{
		a += i;
	}
	Thread.CurrentThread.ManagedThreadId.Dump("4");
	var page = await task;
	//Split happens here the below task will be completed by 
	//some other thread after the task is returned with the result.
	//The below code will be waiting in the
	//Thread Pool. It will be invoked when the task result
	//comes back.
	
	// Part 2
	Thread.CurrentThread.ManagedThreadId.Dump("5");
	"Task returned with page...".Dump();
	Thread.CurrentThread.ManagedThreadId.Dump("6");
}

// You can define other methods, fields, classes and namespaces here