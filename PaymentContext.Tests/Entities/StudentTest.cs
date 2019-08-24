using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var subscription = new Subscription(DateTime.Now);
            var student = new Student("Bruno", "Carvalho" , "2346789", "brunoog33@gmail.com");
            student.AddSubscription(subscription);
        }
    }
}