using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Adress : ValueObjects
    {
        public Adress(string street, string number, string neighborhood, string city, string state, string country, string zpiCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZpiCode = zpiCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Adress.Street", "O nome deve possuir no mínimo 3 letras!")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZpiCode { get; private set; }
    }
}