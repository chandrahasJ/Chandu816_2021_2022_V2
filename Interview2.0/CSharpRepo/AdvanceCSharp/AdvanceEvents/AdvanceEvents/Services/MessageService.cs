using AdvanceEvents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceEvents.Services
{
    public class MailService
    {
        public void OnPaymentDebited(object sender, PaymentEventArgs paymentEventArgs)
        {
            Console.WriteLine($"{paymentEventArgs.Customer.CustomerName} " +
                              $"amount of {paymentEventArgs.Amount} has been debited.\n " +
                              $"Balance of {paymentEventArgs.Balance}");
            Console.WriteLine("Mail sent to " + paymentEventArgs.Customer.EmailId);
        }
    }
    public class MessageService
    {
        public void OnPaymentDebited(object sender, PaymentEventArgs paymentEventArgs)
        {
            Console.WriteLine($"{paymentEventArgs.Customer.CustomerName} " +
                              $"amount of {paymentEventArgs.Amount} has been debited. \n" +
                              $"Balance of {paymentEventArgs.Balance}");
            Console.WriteLine("SMS sent to " + paymentEventArgs.Customer.PhoneNo);
        }
    }
}
