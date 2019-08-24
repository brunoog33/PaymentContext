using System;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode,
         DateTime paidDate,
         DateTime expireDate, 
         decimal total, 
         decimal totalPaid, 
         Email email, 
         string payer, 
         Document document, 
         Adress address) : base(paidDate, expireDate, 
            total, totalPaid, email, payer, document,  address)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}