<Query Kind="Program">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>

public class LivingBeing
{
	public string Name { get; set; }
	public double Weight { get; set; }
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
	public override void Eat(string food) { ChargeTheHumanoid(); }
	private void ChargeTheHumanoid() { Console.WriteLine("I am getting charged."); }
}

// in keyword is important for contra-variant to work.
public interface IContraVariant<in T>
{
	// Not Allowed to read the Type T
	//T GetMethod();
	//T GetProp { get; }

	// Allowed to intake type T in the 
	// method or property 
	 bool SetData(T intakeT);
	 T SetProp{ set;}
}

public class ContraVariant<T> : IContraVariant<T>
{
	public T SetProp { set => throw new NotImplementedException(); }
	
	public bool SetData(T intakeT)
	{
		throw new NotImplementedException();
	}
}

public void SimpleExample(){
	// This is just a example to show you 
	IContraVariant<Animal> contraVariantAnimals = new ContraVariant<Animal>();
	IContraVariant<Sapien> contraVariantSapien = new ContraVariant<Sapien>();
	IContraVariant<LivingBeing> contraVariantLivingBeing = new ContraVariant<LivingBeing>();
	
	//Assignment is reverse from higer to lower..
	IContraVariant<Animal> contraVariantAnimal_2 = contraVariantLivingBeing;
	//or
	IContraVariant<Sapien> contraVariantSapien_2 = new ContraVariant<LivingBeing>();
	
	LivingBeing lb = new LivingBeing();
	Animal an = new Animal();
	lb = an;
	an = (Animal)lb;
}

public void Example2()
{
	LivingBeing livingBeing = new LivingBeing();
	Animal animal = new Animal();
	livingBeing = animal;

	List<Animal> animals = new List<Animal>();
	IEnumerable<LivingBeing> livingBeings = animals;
}

/// <summary>
/// If we remove "in" keyword then the complier will not 
/// be able to identify that T is contravariant. 
/// then this code is not possible
/// Sort(sapiens, new LivingBeingComparer());
/// </summary>
public interface IMyComparer<in T>
{
	int Compare(T object1, T object2);
}

public class LivingBeingComparer : IMyComparer<LivingBeing>
{
	// Compare weight between LivingBeing
	public int Compare(LivingBeing object1, LivingBeing object2)
	{
		return (int)(object1.Weight - object2.Weight);
	}
}

public class SapienComparer : IMyComparer<Sapien>
{
	// If we apply "in" keyword in IMyComparer, 
	// then this code is redundant.
	public int Compare(Sapien object1, Sapien object2)
	{
		return (int)(object1.Weight - object2.Weight);
	}
}

public class CompareAdapter<T> : IComparer<T>
{
	private IMyComparer<T> _innerComparer;
	public CompareAdapter(IMyComparer<T> innerComparer)
	{
		_innerComparer = innerComparer;
	}
	
	public int Compare([AllowNull]T x,[AllowNull] T y)
	{
		return _innerComparer.Compare(x, y);
	}
}

public class Program{
	private static void SortWithInterface(){
		List<Sapien> sapiens = new List<Sapien>(){
			new Sapien(){ Name = "Onkar", Weight=110},
			new Sapien(){ Name = "CJ", Weight=66},
			new Sapien(){ Name = "Govind", Weight=64 },
			new Sapien(){ Name = "Sandeep", Weight=98}
		};

		foreach (var sapien in sapiens)
			Console.WriteLine($"{sapien.Name}-{sapien.Weight}");
			
		Console.WriteLine();
		
		//Sort(sapiens, new SapienComparer());
		
		Sort(sapiens, new LivingBeingComparer());

		foreach (var sapien in sapiens)
			Console.WriteLine($"{sapien.Name}-{sapien.Weight}");
	}
	
	// So as you can see that in Line no. 142, we are providing LivingBeingComparer
	// i.e. IMyComparer<LivingBeing> in place of SapienComparer i.e. IMyComparer<Sapien>
	// but it is not giving any errors. We are trying to replace the child class 
	// with the parent class i.e. we are trying to achieve Contravariance but that 
	// wouldn't have been possible if we haven't added "in" keyword in the 
	// interface IMyComparer<in T>
	private static void Sort(List<Sapien> collection, IMyComparer<Sapien> comparer){
		collection.Sort(new CompareAdapter<Sapien>(comparer));
	}

	private static void SortWithDelegate()
	{
		List<Sapien> sapiens = new List<Sapien>(){
			new Sapien(){ Name = "Onkar", Weight=110},
			new Sapien(){ Name = "CJ", Weight=66},
			new Sapien(){ Name = "Govind", Weight=64 },
			new Sapien(){ Name = "Sandeep", Weight=98}
		};

		foreach (var sapien in sapiens)
			Console.WriteLine($"{sapien.Name}-{sapien.Weight}");

		Console.WriteLine();

		//Sort(sapiens, new SapienComparer());

		Sort(sapiens, new LivingBeingComparer());

		foreach (var sapien in sapiens)
			Console.WriteLine($"{sapien.Name}-{sapien.Weight}");
	}

	private static void Sort(List<Sapien> collection, SortingDelegate<Sapien> sorter)
		=> collection.Sort((o1w, o2w) => sorter(o1w, o2w));
	
	//public static void Main(){
	//	SortWithInterface();
	//}
}

public class Program2{
	private static void SortWithDelegate()
	{
		List<Sapien> sapiens = new List<Sapien>(){
			new Sapien(){ Name = "Onkar", Weight=110},
			new Sapien(){ Name = "CJ", Weight=66},
			new Sapien(){ Name = "Govind", Weight=64 },
			new Sapien(){ Name = "Sandeep", Weight=98}
		};

		foreach (var sapien in sapiens)
			Console.WriteLine($"{sapien.Name}-{sapien.Weight}");

		Console.WriteLine();

		//SortingDelegate<Sapien> sapienSD = (o1w, o2w) => (int)(o1w.Weight - o2w.Weight);
		//Sort(sapiens, sapienSD);

		SortingDelegate<LivingBeing> livingBeingSD = (o1w, o2w) => (int)(o1w.Weight - o2w.Weight);
		Sort(sapiens, livingBeingSD);

		foreach (var sapien in sapiens)
			Console.WriteLine($"{sapien.Name}-{sapien.Weight}");
	}

	// So now you won't be surpise to see that we are able to replace Child class with 
	// parent class in line 206
	private static void Sort(List<Sapien> collection, SortingDelegate<Sapien> sorter)
		=> collection.Sort((o1w, o2w) => sorter(o1w, o2w));

	public static void Main()
	{
		SortWithDelegate();
	}
}

// Contravariance 
// if we don't add "in" keyword then line no. 206 will not be possible.
public delegate int SortingDelegate<in T>(T object1Weight, T object2Weight);












