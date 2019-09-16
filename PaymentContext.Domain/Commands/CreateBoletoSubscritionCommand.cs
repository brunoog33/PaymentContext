using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Payer { get; set; }
        public decimal PayerEmail { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve possuir no mínimo 3 letras!")
                .HasMinLen(LastName, 3, "Name.LastName", "O nome deve possuir no mínimo 3 letras!")
                .HasMaxLen(FirstName, 50, "Name.FristName", "O nome deve possuir no máximo 50 letras!")
                .HasMaxLen(LastName, 50, "Name.LastName", "O nome deve possuir no máximo 50 letras!")
            );
        }
    }
}