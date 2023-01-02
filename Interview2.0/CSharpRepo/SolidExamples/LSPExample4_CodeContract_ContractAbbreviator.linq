<Query Kind="Statements">
  <Namespace>System.Diagnostics.Contracts</Namespace>
</Query>


public class Employee
{
	public int Salary { get; private set; }

	[ContractAbbreviatorAttribute()]
	private void CheckContracts(int amount)
	{
		Contract.Requires(amount > 0,
				"Amount should be greater than zero");
	}

	public int IncreaseSalary(int amount)
	{
		CheckContracts(amount);
		Salary += amount;
		return Salary;
	}

	public void DecreaseSalary(int amount, out int updatedSalary)
	{
		CheckContracts(amount);
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
	emp.DecreaseSalary(100, out updatedSalary); //No warnings
}
