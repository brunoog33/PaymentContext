using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Email : ValueObjects
    {
        public Email(string adress)
        {
            Adress = adress;
        }

        public string Adress { get; private set; }
    }
}