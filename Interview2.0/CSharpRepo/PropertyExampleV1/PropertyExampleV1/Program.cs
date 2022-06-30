using System;

namespace PropertyExampleV1
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(101,"Chandrika", false, 5000.00, Cities.Bengaluru, "Karantaka");
            Console.WriteLine($"Customer ID :> {customer.CustId}");
            Console.WriteLine($"Customer Status :> {(customer.Status == true ? "Active" : "In-Active")}");

            Console.WriteLine($"Customer Name :> {customer.CustName}");
            customer.CustName = "Chandrika Poojari"; //  Assignment fails since Status is In-Active
            Console.WriteLine($"Modified Customer Name :> {customer.CustName}");

            Console.WriteLine($"Customer Balance :> {customer.Balance}");
            customer.Balance -=3000; // Assignment fails since Status is In-Active
            Console.WriteLine($"Modified Customer Balance :> {customer.Balance}");
             
            customer.Status = true;
            Console.WriteLine($"Customer Status :> {(customer.Status == true ? "Active" : "In-Active")}");

            customer.CustName = "Chandrika Poojari"; // Assignment succeeded since Status is Active
            Console.WriteLine($"Modified Customer Name :> {customer.CustName}");

            customer.Balance -= 3000; // Assignment succeeded since Status is Active
            Console.WriteLine($"Modified Customer Balance :> {customer.Balance}");

            customer.Balance -= 1600; // Assignment failed since Balance will be less than 500
            Console.WriteLine($"Assignment Failed Customer Balance :> {customer.Balance}");

            customer.Balance -= 1400; // Assignment succeeded since Balance will be greater than 500
            Console.WriteLine($"Assignment Passed Modified Customer Balance :> {customer.Balance}");

            Console.WriteLine($"Current City :> {customer.City}");
            customer.City = Cities.Mumbai; 
            Console.WriteLine($"Modified City :> {customer.City}");

            Console.WriteLine($"Current State :> {customer.State}");
            //customer.State = "Maharastra"; B'Coz current class is not a child class of Customer
            Console.WriteLine($"Modified State :> {customer.State}");

            Console.WriteLine($"Current Country :> {customer.Country}");

            Console.ReadLine();
        }
    }
}
