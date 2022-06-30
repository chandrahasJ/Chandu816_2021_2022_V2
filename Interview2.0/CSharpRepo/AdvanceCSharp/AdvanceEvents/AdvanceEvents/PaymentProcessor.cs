using AdvanceEvents.Models;
using AdvanceEvents.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceEvents
{
    interface IPaymentProcessor
    {
        bool AddPayment(Customer customer, decimal amount); 
    }

    public class PaymentEventArgs : EventArgs
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
    }

    public class PaymentProcessor : IPaymentProcessor
    { 
        public event EventHandler<PaymentEventArgs> PaymentProccessed;
        public PaymentProcessor() { }

        private void OnPaymentDebited(PaymentEventArgs paymentEventArgs)
        {
            if (PaymentProccessed != null)
                PaymentProccessed(this, new PaymentEventArgs()
                {
                    Amount = paymentEventArgs.Amount,
                    Balance = paymentEventArgs.Balance,
                    Customer = paymentEventArgs.Customer
                }) ;
        }

        public bool AddPayment(Customer customer, decimal amount)
        {
            Console.WriteLine("Payment Made");
            OnPaymentDebited(new PaymentEventArgs()
            {
                Amount = amount,
                Balance = customer.Account.Balance + amount,
                Customer = customer
            }); 
            return true;
        }
    }
}
