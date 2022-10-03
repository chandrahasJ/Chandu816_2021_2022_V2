using AdvanceEvents.Models;
using AdvanceEvents.Repos;
using AdvanceEvents.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new CustomerRepo().GetCustomers();

            PaymentProcessor paymentProcessor 
                        = new PaymentProcessor(); //Publisher
            var messageService = new MessageService(); //Subscriber
            var mailService = new MailService();       //Subscriber

            //Attaching subscriber to publisher...
            paymentProcessor.PaymentProccessed += 
                                    messageService.OnPaymentDebited;
            paymentProcessor.PaymentProccessed += 
                                    mailService.OnPaymentDebited;

            paymentProcessor.AddPayment(
                                customers.Where(x => x.CustomerId == 1)
                                         .FirstOrDefault(),
                                500000.0M);
            Console.ReadLine();
        }
        
    }
}
