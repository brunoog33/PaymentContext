using System;
using System.Collections.Generic;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastDateUpdate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastDateUpdate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments 
        { 
            get 
            {
                return _payments.ToArray();
            }; 
            private set; 
        }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", 
                    "A data de pagamento deve ser futura!")
                );

            // if (IsValid) Só adiciona se for valido o balta deixa para validar no banco
            _payments.Add(payment);
        }

        public void Activate() 
        {
            Active = true;
            LastDateUpdate = DateTime.Now;
        }

        public void Inactivate() 
        {
            Active = false;
            LastDateUpdate = DateTime.Now;
        }
    }
}