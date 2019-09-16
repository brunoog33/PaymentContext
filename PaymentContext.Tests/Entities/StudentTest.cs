using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Adress _adress;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("34225545806", EDocumentType.CPF);
            _email = new Email("bataman@dc.com");
            _adress = new Adress("Rua 1", "1234", "Bairro Legal", "Getulina", "SP", "BR", 
                "16450000");
            var _student = new Student(_name, _document, _email);
            var _subscription = new Subscription(null);
        }

       [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 
                10, 10, _email, "Wayne Corp", _document, _adress);
            
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 
                10, 10, _email, "Wayne Corp", _document, _adress);
            
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
        
    }
}