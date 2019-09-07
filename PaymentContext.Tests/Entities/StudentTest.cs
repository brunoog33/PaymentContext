using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var name = new Name("Bruno", "Carvalho");
            foreach (var not in name.Notifications)
            {
                not.Message;
            } 
        }
    }
}