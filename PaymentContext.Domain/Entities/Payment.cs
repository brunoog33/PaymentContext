using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObject;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate,
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid, 
            Email email, 
            string payer, 
            Document document, 
            Adress address)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Email = email;
            Payer = payer;
            Document = document;
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O Total não pode ser zero!")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", 
                    "O valor pago é menor que o total a ser recebido!")
                
            );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Email Email { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Adress Address { get; private set; }
    }
}