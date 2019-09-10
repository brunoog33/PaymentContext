using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObject;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Adress Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions 
        { 
            get
            {
                return _subscriptions.ToArray();
            } 
        }

        public void AddSubscription(Subscription subscription) 
        {
            var hasSubcriptionActive = false;
            foreach(var subs in _subscriptions)
            {
               if (subs.Active)
                hasSubcriptionActive = true;
            }
            
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubcriptionActive, "Student.Subscription", 
                    "Você já tem uma assinatura atuva")
                .AreEquals(0, subscription.Payments.Count == 0,
                    "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
            );
              
           /* Alternativa
           if (hasSubcriptionActive)
                AddNotification("Student.Subscription", "Você já tem uma assinatura ativa!"); */ 
        }

        
    }
}