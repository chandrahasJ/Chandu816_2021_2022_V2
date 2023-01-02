<Query Kind="Statements">
  <Namespace>System.Diagnostics.Contracts</Namespace>
</Query>

[ContractClassAttribute(typeof(EmployeeContract))]
public interface IEmployee
{
	int Salary { get; }
	int IncreaseSalary(int amount);
	void DecreaseSalary(int amount, out int updatedSalary);
}

/// <summary>
/// For all the class those have implemented IEmployee interface
/// The contracts will run
/// This makes it easy to manage the contract.
/// </summary>
[ContractClassForAttribute(typeof(IEmployee))]
public abstract class EmployeeContract : IEmployee
{
	public int Salary { get; private set; }

	[ContractInvariantMethod]
	private void InvvariantChecks()
	{
		Contract.Invariant(Salary != 0);
	}

	public int IncreaseSalary(int amount)
	{
		Contract.Requires(amount > 0, "Amount should be greater than zero.");
		return 0;
	}

	public void DecreaseSalary(int amount, out int updatedSalary)
	{
		updatedSalary = 0;
		Contract.Requires(amount > 0, "Amount should be greater than zero.");
		Contract.Ensures(Contract.ValueAtReturn(out updatedSalary) != Salary,
						"Updated Salary should not be equal to current salary");
	}
}

public class Employee : IEmployee
{
	public int Salary { get; private set; }

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
	emp.DecreaseSalary(100, out updatedSalary); //No warnings
}
