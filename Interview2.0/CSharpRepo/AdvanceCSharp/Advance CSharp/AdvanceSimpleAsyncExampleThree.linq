<Query Kind="Expression">
  <Output>DataGrids</Output>
</Query>

//void Main()
//{
//	MakeTea();	
//
//	"Drink the tea".Dump();
//}

public string MakeTea()
{
	var water = BoilWater();

	"take the cups out".Dump();

	"put tea in cups".Dump();

	var tea = $"pour {water} in cups".Dump();

	return tea;
}


public string BoilWater()
{
	"start the tea pot".Dump();

	"waiting for the tea pot".Dump();

	Task.Delay(5000).GetAwaiter().GetResult();

	"Tea pot finsihed boiling...".Dump();

	return "water";
}
