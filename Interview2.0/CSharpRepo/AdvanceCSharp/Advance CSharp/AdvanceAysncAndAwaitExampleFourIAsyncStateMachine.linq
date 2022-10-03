<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	// Part 1
	var client = new HttpClient();
	var task = client.GetStringAsync(@"http:\\www.google.com");
	int a = 0;
	for (int i = 0; i < 100000; i++)
	{
		a += i;
	}
	$"Value of a is {a}".Dump();
	var page = await task;
	
	// Part 2
	"Task returned with page...".Dump();
}