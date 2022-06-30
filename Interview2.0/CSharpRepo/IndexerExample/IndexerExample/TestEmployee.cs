using System;
using System.Collections.Generic;
using System.Text;

namespace IndexerExample
{
    public enum Department {  Software, Accounts, HR, Admin , IT}
    public enum Designation { Jr_Enigneer,Sr_Enigneer,Manager,Head_HR,Admin}
    public enum EmployeeIndexerName { EmployeeId= 1, EmployeeName, Salary , Department, Designation }
    public class Employee
    {
        int employeeId; string employeeName; double salary; Department department; Designation designation; 
        public Employee(int employeeId, string employeeName, double salary, Department department, Designation designation)
        {
            this.employeeId = employeeId;  this.employeeName = employeeName;   this.salary = salary;
            this.department = department;  this.designation = designation;
        }
        public object this[int index]
        {
            get
            {
                if (index == 1) return employeeId;
                else if (index == 2) return employeeName;
                else if (index == 3) return salary;
                else if (index == 4) return department;
                else if (index == 5) return designation;
                return null;
            }
            set
            {
                if (index == 1) employeeId = (int)value;
                else if (index == 2)   employeeName = (string)value;
                else if (index == 3)   salary = (double)value;
                else if (index == 4)   department = (Department)value;
                else if (index == 5)   designation =(Designation)value;                
            }
        }

        public object this[string name]
        {
            get
            {
                if (name.ToUpper() == nameof(employeeId).ToUpper()) return employeeId;
                else if (name.ToUpper() == nameof(employeeName).ToUpper()) return employeeName;
                else if (name.ToUpper() == nameof(salary).ToUpper()) return salary;
                else if (name.ToUpper() == nameof(department).ToUpper()) return department;
                else if (name.ToUpper() == nameof(designation).ToUpper()) return designation;
                return null;
            }
            set
            {
                if (name.ToUpper() == nameof(employeeId).ToUpper()) employeeId = (int)value;
                else if (name.ToUpper() == nameof(employeeName).ToUpper()) employeeName = (string)value;
                else if (name.ToUpper() == nameof(salary).ToUpper()) salary = (double)value;
                else if (name.ToUpper() == nameof(department).ToUpper()) department = (Department)value;
                else if (name.ToUpper() == nameof(designation).ToUpper()) designation = (Designation)value;
            }
        }

        public override string ToString()
        {
            return $"Employee Id :> {employeeId},\t Employee Name :> {employeeName},\t Employee Salary :> {salary}\n" +
                   $"Employee Department :> {department},\t Employee Designation :> {designation}\n";
        }
    }
}
