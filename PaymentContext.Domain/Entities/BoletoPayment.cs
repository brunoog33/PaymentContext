using System;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, 
         string boletoNumber,
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
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}

