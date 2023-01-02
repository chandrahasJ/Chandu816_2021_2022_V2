<Query Kind="Program">
  <Namespace>System.Diagnostics.Contracts</Namespace>
</Query>


public class Employee
{
	public int Salary { get; private set; }

	[ContractInvariantMethod]
	private void InvvariantChecks()
	{
		Contract.Invariant(Salary != 0);
	}
	
	public int IncreaseSalary(int amount)
	{
		Salary += amount;
		return Salary;
	}

	public void DecreaseSalary(int amount, out int updatedSalary)
	{  
		updatedSalary = Salary - amount;
		Salary = updatedSalary;
	}
}

void Main()
{
	 Employee emp = new Employee();
	 emp.IncreaseSalary(-1); // This will provoke a warning 
	 emp.DecreaseSalary(-1, out int updatedSalary); // This will provoke a warning.
	 
	 emp.IncreaseSalary(1000); //No warnings
	 emp.DecreaseSalary(100,out updatedSalary); //No warnings
}
