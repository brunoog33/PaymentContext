using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Name : ValueObjects
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve possuir no mínimo 3 letras!")
                .HasMinLen(LastName, 3, "Name.LastName", "O nome deve possuir no mínimo 3 letras!")
                .HasMaxLen(FirstName, 50, "Name.FristName", "O nome deve possuir no máximo 50 letras!")
                .HasMaxLen(LastName, 50, "Name.LastName", "O nome deve possuir no máximo 50 letras!")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}