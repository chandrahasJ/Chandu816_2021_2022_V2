<Query Kind="Program" />

public interface IStandardCommanActivy
{
	void Stand();
	void Sit();
	void Run();
}

public interface ILivingBeing : IStandardCommanActivy
{
	void Eat(string food);
	void Defecation();	
}

public interface ISapien : ILivingBeing
{
	void Read(string bookName);
}

public interface IHumanoid : IStandardCommanActivy
{
	void charge(bool isPluggedIn);
}

public interface IAnimal : ILivingBeing
{
	void Hunt(string preyName);
}

public class Sapien : ISapien
{
	public virtual void Eat(string food) { Console.WriteLine("Eat " + food); }
	public virtual void Run() { Console.WriteLine("Run"); }
	public virtual void Sit() { Console.WriteLine("Sit"); }
	public virtual void Stand() { Console.WriteLine("Stand"); }
	public virtual void Defecation() { Console.WriteLine("Defecating"); }
	public virtual void Read(string bookName) { Console.WriteLine("Reading " + bookName); }
}

public class Animal : IAnimal
{
	public virtual void Hunt(string preyName) 
	{ Console.WriteLine("Hunting " + preyName); }
	public virtual void Eat(string food) { Console.WriteLine("Eat " + food); }
	public virtual void Run() { Console.WriteLine("Run"); }
	public virtual void Sit() { Console.WriteLine("Sit"); }
	public virtual void Stand() { Console.WriteLine("Stand"); }
	public virtual void Defecation() { Console.WriteLine("Defecating"); }
}

public class Humaniod : IHumanoid, IStandardCommanActivy
{
	public virtual void charge(bool isPluggedIn) 
	{  Console.WriteLine("charging " + (isPluggedIn ? "Yes" : "No"));  }	
	public virtual void Run() {Console.WriteLine("Run");}
	public virtual void Sit() { Console.WriteLine("Sit"); }
	public virtual void Stand() { Console.WriteLine("Stand"); }
}

public static class Test
{
	public static void CheckHumans(ISapien sapien, string food)
	{
		sapien.Sit();
		sapien.Read("The Orville List");
		sapien.Stand();
		sapien.Run();
		sapien.Eat(food);
		sapien.Defecation();
	}

	public static void CheckHumanoid(IHumanoid humanoid, bool isPluggedIn)
	{
		humanoid.Sit();
		humanoid.Stand();
		humanoid.Run();
		humanoid.charge(true);
	}

	public static void CheckAnimals(IAnimal animal, string food)
	{
		animal.Sit();
		animal.Stand();
		animal.Run();
		animal.Hunt("Deer");
		animal.Eat(food);
		animal.Defecation();
	}
}

void Main()
{
	ISapien sapien = new Sapien();
	Test.CheckHumans(sapien, "Pizza");
	Console.WriteLine("---------------");
	IHumanoid humaniod = new Humaniod();
	Test.CheckHumanoid(humaniod, true);
	Console.WriteLine("---------------");
	IAnimal animal = new Animal();
	Test.CheckAnimals(animal, "Meat");
}
