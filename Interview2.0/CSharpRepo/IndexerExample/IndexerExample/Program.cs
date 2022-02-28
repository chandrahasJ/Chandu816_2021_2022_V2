    using System;

namespace IndexerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(1001,"Chandrahas",2500000, Department.Software,Designation.Sr_Enigneer);
            Console.WriteLine($"Employee Id :> {employee[1]}");
            Console.WriteLine($"Employee Name :> {employee[2]}");
            Console.WriteLine($"Employee Salary :> {employee[3]}");
            Console.WriteLine($"Employee Department :> {employee[4]}");
            Console.WriteLine($"Employee Designation :> {employee[5]}");

            employee[2] = "Chandrahas Poojari";
            employee[EmployeeIndexerName.Salary.ToString()] = 30000000.00;
            employee[(int)EmployeeIndexerName.Designation] = Designation.Manager;

            Console.WriteLine("---------------After changes --- ------------------");

            Console.WriteLine($"Employee Id :> {employee[EmployeeIndexerName.EmployeeId.ToString()]}");
            Console.WriteLine($"Employee Name :> {employee[EmployeeIndexerName.EmployeeName.ToString()]}");
            Console.WriteLine($"Employee Salary :> {employee[EmployeeIndexerName.Salary.ToString()]}");
            Console.WriteLine($"Employee Department :> {employee[EmployeeIndexerName.Department.ToString()]}");
            Console.WriteLine($"Employee Designation :> {employee[EmployeeIndexerName.Designation.ToString()]}");

                Console.ReadLine();
        }
    }
}
