<Query Kind="Program" />

public class LivingBeing
{
	public string Name { get; set; }
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

public void WithArrayType(){
	var Animals = new Animal[]{
		new Animal{ Name = "Cat"},
		new Animal{ Name = "Dog"},
		new Animal{ Name = "Deer"},
	};
	// Perfectly valid.Since Animals are LivingBeings.
	LivingBeing[] LivingBeings = Animals;
	// We can loop through both LivingBeings or Animals
	foreach (LivingBeing livingBeing in LivingBeings)
		Console.WriteLine(livingBeing.Name);

	// In Array we are not able to add since arrays are of fixed size
	// but we can override the value in the parent class array
	// Since Sapiens are LivingBeing.
	// This breaks the LSP. 
	// This below line generates a run-time error not a 
	// Compile-Time error
	//LivingBeings[1] = new Sapien{ Name="Chandrahas"};
	LivingBeings[2] = new Animal{ Name="Camel"};
	
	// Not able to override since Animals are not Sapiens
	//Animals[0] = new Sapien { Name = "Anup" };

	foreach (LivingBeing livingBeing in LivingBeings)
		Console.WriteLine(livingBeing.Name);
}

void Main()
{
	WithArrayType();
	//BreakLSP();
	//WithStandardGeneric();
	//HomeMadeGeneric();
}

public class WorldOfLivingBeing
{
	private List<LivingBeing> _items = new List<LivingBeing>();

	public virtual LivingBeing Get(int idx) => _items[idx];
	public virtual void Add(LivingBeing livingBeing) => _items.Add(livingBeing);
}

public class WorldOfAnimal : WorldOfLivingBeing
{
	//This were we break LSP as we are casting
	public new Animal Get(int idx) => (Animal)base.Get(idx);
	public void Add(Animal animal) => base.Add(animal);
}


public void WithStandardGeneric()
{
	List<Animal> worldOfAnimals = new List<UserQuery.Animal>(){
		new Animal(){ Name = "Deer"},
		new Animal(){ Name = "Snake"},
		new Animal(){ Name = "Dog"},
	};		
	IEnumerable<LivingBeing> worldOfLivingBeings;
	
	//Here we are creating inheritance between 
	//IEnumerable<LivingBeing> and List<Animal>
	// by assigning worldOfAnimals to worldOfLivingBeings
	//Since Animal is dervied class & LivingBeing is base Class
	worldOfLivingBeings = worldOfAnimals;
	
	//Now since worldOfLivingBeings has the reference of worldOfAnimals
	//Below line 48 & 49 will be execute without any issue.
	foreach (var being in worldOfLivingBeings)
		Console.WriteLine(being.Name);
	
	//We can add more animal type in worldOfAnimals
	worldOfAnimals.Add(new Animal {Name = "Cat"});
	
	Console.WriteLine("--------");
	foreach (var being in worldOfLivingBeings)
		Console.WriteLine(being.Name);

	// Below line will gives us error since we won't be able to 
	// Cast Sapien to Animal Type.
	//worldOfAnimals.Add(new Sapien {Name = "Chandrahas"});
	
	// Below Line will gives us error 
	// Since worldOfLivingBeings is an IEnumerable 
	// We cannot add or remove from worldOfLivingBeings.
	//worldOfLivingBeings.Add(new Sapien {Name = "Ptomey"});
}

public void BreakLSP()
{
	WorldOfAnimal worldOfAnimal = new WorldOfAnimal();
	worldOfAnimal.Add(new Animal() { Name = "Dog" });
	Console.WriteLine(worldOfAnimal.Get(0).Name);

	// Till this point everything is ok 
	// Now lets make things interesting 
	worldOfAnimal.Add(new Sapien() { Name = "Chandrahas" });
	// Now don't you thing it is weird that we are adding 
	// Sapiens in World Of Animal & it is not giving us errors
	// It is because WorldOfAnimal is inherit by WorldOfLivingBeing

	// Now lets see things haywire by Breaking LSP by 
	// trying to cast something which is not possible.
	// i.e. Casting Sapien to Animal. 
	Console.WriteLine(worldOfAnimal.Get(1).Name);
}



// out make the T as covariant parameter.
// The out keyword can only be defined in Generic Interfaces
// The out keyword tell that it can be used only for return types.
// If we remove the out keyword we will loose the ability of inherit.
public interface IWorld<out T>
{
	T Get(int idx);
	IEnumerable<T> GetAll();
}

public class World<T> : IWorld<T>
{
	private List<T> _items = new List<T>();

	public T Get(int idx) => _items[idx];
	public IEnumerable<T> GetAll() => _items;
	public void Add(T t) => _items.Add(t);
}

public void HomeMadeGeneric()
{
	World<Animal> worldOfAnimals = new World<Animal>();
	worldOfAnimals.Add(new Animal() { Name = "Deer" });
	worldOfAnimals.Add(new Animal() { Name = "Snake" });
	worldOfAnimals.Add(new Animal() { Name = "Dog" });

	IWorld<LivingBeing> worldOfLivingBeings;
	// This below is working since we have declared T as Covariant 
	// in IWorld interface and World<T> has implemented the IWorld
	// interface.
	worldOfLivingBeings = worldOfAnimals;

	//Now since worldOfLivingBeings has the reference of worldOfAnimals
	//Below line 48 & 49 will be execute without any issue.
	foreach (var being in worldOfLivingBeings.GetAll())
		Console.WriteLine(being.Name);

	//We can add more animal type in worldOfAnimals
	worldOfAnimals.Add(new Animal { Name = "Cat" });

	Console.WriteLine("--------");
	foreach (var being in worldOfLivingBeings.GetAll())
		Console.WriteLine(being.Name);

	// Below line will gives us error since we won't be able to 
	// Cast Sapien to Animal Type.
	//worldOfAnimals.Add(new Sapien {Name = "Chandrahas"});

	// Below Line will gives us error 
	// Since worldOfLivingBeings is an IWorld 
	// which don't have add or remove capablities.
	//worldOfLivingBeings.Add(new Sapien {Name = "Ptomey"});
}


// out keyword is important for covariance to work.
public interface ICovariant<out T>
{
	// Allowed to read the Type T
	T GetMethod();
	T GetProp {get;}
	
	// Not allowed to intake type T in the 
	// method or property 
	// bool SetData(T intakeT);
	// T SetProp{get; set;}
}

public class Covariant<T> : ICovariant<T>
{ 
	public T GetProp => throw new NotImplementedException();

	public T GetMethod()
	{
		throw new NotImplementedException();
	}
}

public void SimpleExample(){
	// This is just a example to show you 
	ICovariant<Animal> covariantAnimals = new Covariant<Animal>();
	ICovariant<Sapien> covariantSapien = new Covariant<Sapien>();
	
	ICovariant<LivingBeing> covariantLivingBeing = covariantAnimals;
	//or
	covariantLivingBeing = covariantSapien;
}

public void Example2(){
	LivingBeing livingBeing = new LivingBeing();
	Animal animal = new Animal();
	livingBeing = animal;
	
	List<Animal> animals = new List<UserQuery.Animal>();
	IEnumerable<LivingBeing> livingBeings = animals;
}