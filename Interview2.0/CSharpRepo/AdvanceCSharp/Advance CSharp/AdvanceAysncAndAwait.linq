<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


async Task Main()
{
	await MakeTeaAsync();

	"Drink the tea".Dump();
}


public async Task<string> MakeTeaAsync()
{
	var boilWaterTask = BoilWaterAsync();

	"take the cups out".Dump();

	"put tea in cups".Dump();
	
	var water = await boilWaterTask;

	var tea = $"pour {water} in cups".Dump();

	return tea;
}

public async Task<string> BoilWaterAsync()
{
	"start the tea pot".Dump();

	"waiting for the tea pot".Dump();

	await Task.Delay(5000);

	"Tea pot finsihed boiling...".Dump();

	return "water";
}

