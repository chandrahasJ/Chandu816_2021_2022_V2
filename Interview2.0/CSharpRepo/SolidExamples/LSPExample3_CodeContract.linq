<Query Kind="Program">
  <Namespace>System.Diagnostics.Contracts</Namespace>
</Query>


// You can define other methods, fields, classes and namespaces here

public class Employee
{
	public int Salary { get; private set; }
	
	public virtual int IncreaseSalary(int amount)
	{
		Contract.Requires(amount > 0);
		Contract.Ensures(Contract.Result<int>() != 0);
		Contract.Ensures(Contract.OldValue<int>(Salary) != Salary);		
		
		Salary += amount;
		
		return Salary;
	}	
	
	public virtual void MonthlySalary(int amount, out int updatedSalary)
	{
		Contract.Ensures(Contract.OldValue(Salary) != Salary);
		Contract.Ensures(Contract.ValueAtReturn(out updatedSalary) < Salary);
		updatedSalary = 0;
		
		updatedSalary = Salary - amount;
		Salary = updatedSalary;		
	}
}

void Main()
{
	Calculations cal = new Calculations();
	cal.Division(6,5);
}
