<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

public async Task Main()
{
	 await  BuyTicketAsync();
	"Happy Journey".Dump();
}

public async Task BuyTicketAsync()
{
	"Creating a request".Dump();
	HttpClient client = new HttpClient();
	"Request to server to get ticket price & buy the ticket".Dump();
	Task<string> getPriceData =
			client.GetStringAsync(new Uri("https://www.irctc.co.in/nget/"));
	"waiting for http client to download the price".Dump();
	//await will signal that it is time taking process so it will skip the 
	//below section it will be executed after httpclient brings back the result.
	//For how & why question we need to check AsyncStateMachine.
	string urlData = await getPriceData;
	var price = Regex.Replace(urlData, "[^0-9]+", "");

	$"Ticket was bought at Rs.{price.Substring(2, 2)}".Dump();
}