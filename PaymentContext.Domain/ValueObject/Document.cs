using Flunt.Validations;
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

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Numver", "Documento inválido!")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate() {
            if (Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;
            if (Type == EDocumentType.CPF && Number.Length == 11)  
                return true;
            return false;
        }
    }
}