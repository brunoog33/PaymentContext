using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObject
{
    public class Document : ValueObjects
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}