using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Name : ValueObjects
    {
        public Name(string fristName, string lastName)
        {
            FristName = fristName;
            LastName = lastName;
        }

        public string FristName { get; private set; }
        public string LastName { get; private set; }
    }
}