<Query Kind="Program" />

public class LivingBeing
{
	public virtual void Eat(string food) { Console.WriteLine("Eat " + food); }
	public virtual void Run() { Console.WriteLine("Run"); }
	public virtual void Sit() { Console.WriteLine("Sit"); }
	public virtual void Stand() { Console.WriteLine("Stand"); }
	public virtual void Defecation() { Console.WriteLine("Defecating"); }
}

public class Sapien : LivingBeing
{
	public virtual void Read(string bookName) 
	{ Console.WriteLine("Reading " + bookName); }
}

public class Animal : LivingBeing
{
	public virtual void Hunt(string preyName) 
	{ Console.WriteLine("Hunting " + preyName); }
}

public class Humaniod : Sapien
{
	//This were we are Breaking LSP.
	public override void Eat(string food){ ChargeTheHumanoid();}
	private void ChargeTheHumanoid(){Console.WriteLine("I am getting charged.");} 
}

public static class Test{
	public static void Check(LivingBeing livingBeing, string food)
	{
		livingBeing.Sit();
		livingBeing.Stand();
		livingBeing.Run();
		// This code will work but it will give you suprises since it violates LSP, 
		// if object is Sapien then no issue sapien can eat, defecat 
		// but if the object is humaniod then it doesn't eat food or defecat.
		// But if food is electricity humans die if they are exposed to it.
		livingBeing.Eat(food);
		livingBeing.Defecation();
		//All Living Being Cannot Read.. This Breaks LSP..
		//livingBeing.Read("The Orville List");
	}
}

void Main()
{
	Sapien sapiens = new Sapien();
	Test.Check(sapiens,"Pizza");
	Console.WriteLine("---------------");
	Humaniod humaniod = new Humaniod();
	Test.Check(humaniod,"");
	Console.WriteLine("---------------");
	Animal animal = new Animal();
	Test.Check(animal, "Meat");
}
