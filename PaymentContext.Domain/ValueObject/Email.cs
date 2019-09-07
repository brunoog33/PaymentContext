using Flunt.Validations;
using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Email : ValueObjects
    {
        public Email(string adress)
        {
            Adress = adress;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Adress, "Email.Adress", "E-mail inválido!")
            );
        }

        public string Adress { get; private set; }
    }
}