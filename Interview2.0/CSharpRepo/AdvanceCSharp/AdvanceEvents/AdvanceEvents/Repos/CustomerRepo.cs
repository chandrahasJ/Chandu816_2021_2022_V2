using AdvanceEvents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceEvents.Repos
{
    public class CustomerRepo
    {
        public List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    CustomerId = 1,
                    CustomerName = "Chandrahas Poojari",
                    EmailId = "cj@cj.com",
                    PhoneNo = "022-2836587",
                    Account = new Account()
                    {
                        AccountId = 1,
                        AccountNumber = 81681607,
                        Balance = 1000000000000000.0M
                    }
                },
                new Customer()
                {
                    CustomerId = 1,
                    CustomerName = "Chandrika",
                    EmailId = "chandrika@cj.com",
                    PhoneNo = "022-12345678",
                    Account = new Account()
                    {
                        AccountId = 1,
                        AccountNumber = 81681697,
                        Balance = 1000000000000000.0M
                    }
                },
                new Customer()
                {
                    CustomerId = 1,
                    CustomerName = "Sandeep",
                    EmailId = "Sandeep@cj.com",
                    PhoneNo = "022-12345678",
                    Account = new Account()
                    {
                        AccountId = 1,
                        AccountNumber = 98714701,
                        Balance = 1000000000000000.0M
                    }
                },
            };
        }
    }
}
