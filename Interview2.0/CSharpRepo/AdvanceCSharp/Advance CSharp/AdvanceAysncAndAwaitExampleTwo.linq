<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//void Main()
//{
//	BoardTheTrain();	
//
//	"Happy Journy".Dump();
//}

void BoardTheTrain()
{
	"Get out of the house".Dump();
	"Reach the Station".Dump();
	var ticket = BuyTheTicket();
	$" go to the platform with the {ticket} ".Dump();
	$" and board the ticket".Dump();
}

string BuyTheTicket(){
	"Get in the queue to buy the ticket".Dump();
	"Wait in the line till your turn comes".Dump();
	Task.Delay(5000).GetAwaiter().GetResult();
	"Give the money buy the ticket".Dump();
	return "Ticket";
}


async Task Main()
{
	await BoardTheTrainAsync();	

	"Happy Journy".Dump();
}

async Task BoardTheTrainAsync(){
	"Get out of the house".Dump();
	var ticket = await BuyTheTicketAsync();
	"Reach the Station".Dump();	
}


async Task<string> BuyTheTicketAsync()
{
	"Ticket bought via Phone".Dump();
	await Task.Delay(5000);	
	return "Ticket";
}
