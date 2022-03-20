using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceEvents.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public Account Account { get; set; }
    }
}
