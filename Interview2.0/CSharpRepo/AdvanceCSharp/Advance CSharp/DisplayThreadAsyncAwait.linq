<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

async Task Main()
{
	Thread.CurrentThread.ManagedThreadId.Dump("1");
	var client = new HttpClient();
	Thread.CurrentThread.ManagedThreadId.Dump("2");
	var task = client.GetStringAsync(@"http:\\www.google.com");
	Thread.CurrentThread.ManagedThreadId.Dump("3");
	var a = 0;
	for (int i = 0; i < 100_000_0000; i++)
	{
		a += i;
	}
	Thread.CurrentThread.ManagedThreadId.Dump("4");
	var page =await task;
	Thread.CurrentThread.ManagedThreadId.Dump("5");
	Thread.CurrentThread.ManagedThreadId.Dump("6");
}

// You can define other methods, fields, classes and namespaces here