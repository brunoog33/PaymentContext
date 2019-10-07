using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscritionhandlerTest
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruno";
            command.LastName = "Carvalho";
            command.Document = "";
            command.Email = "brunoog33@hotmail.com";
            command.BarCode = "1234567890";
            command.BoletoNumber = "9999999999";
            command.PaymentNumber = "21345478";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddDays(10);
            command.Total = 12000;
            command.TotalPaid = 12000;
            command.Payer = "Bruno Carvalho";
            command.PayerDocument = "1234567890";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "brunoog33@hotmail.com";
            command.Street = "Rua Ataliba Leonel";
            command.Number = "123";
            command.Neighborhood = "Centro";
            command.City = "Getulina";
            command.State = "São Paulo";
            command.Country = "Brasil";
            command.ZipCode = "16450-000";

            handler.Handle(command);
            Assert.AreEqual(false, command.Valid);
        }
    }
}