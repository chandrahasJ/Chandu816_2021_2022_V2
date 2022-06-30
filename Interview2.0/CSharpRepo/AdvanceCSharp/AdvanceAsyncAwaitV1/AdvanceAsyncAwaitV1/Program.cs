using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvanceAsyncAwaitV1
{
    class Program
    {
        static async Task Main(string[] args)
        {
			// Part 1
			var client = new HttpClient();
			Console.WriteLine($"Start Process");
			var task = client.GetStringAsync(@"http:\\www.google.com");
			int a = 0;
			for (int i = 0; i < 100000; i++)
			{
				a += i;
			}
			Console.WriteLine($"Value of a is {a}");
			var page = await task;

			// Part 2
			Console.WriteLine($"Task returned with page...");
		}
    }
}
