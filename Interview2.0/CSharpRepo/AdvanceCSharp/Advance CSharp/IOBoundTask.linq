<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

public void Main(){
	BuyTicket();
	"Happy Journey".Dump();
}

public void BuyTicket(){
	"Creating a request".Dump();	
	WebClient client = new WebClient();
	"Request to server to get ticket price & buy the ticket".Dump();
	string getTicketPrice = 
				client.DownloadString("https://www.irctc.co.in/nget/");
	"waiting for web client to download the price".Dump();
	//Below code will not be executed till web client was downloading the string..
	var price = Regex.Replace(getTicketPrice, "[^0-9]+","");
	 
	$"Ticket was bought at Rs.{price.Substring(2,2)}".Dump();
}