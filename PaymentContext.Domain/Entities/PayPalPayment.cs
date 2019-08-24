using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode,
         DateTime paidDate,
         DateTime expireDate, 
         decimal total, 
         decimal totalPaid, 
         string email, 
         string payer, 
         string document, 
         string address) : base(paidDate, expireDate, 
            total, totalPaid, email, payer, document,  address)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}