using System;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class CredCardPayment : Payment
    {
        public CredCardPayment(string cardHolderName,
         string cardNumber, 
         string lastTransactionNumber,
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
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}