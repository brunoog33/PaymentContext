using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(new Name("Aluno ", i.ToString()), 
                                          new Document("1234567" + i.ToString(), EDocumentType.CPF),
                                          new Email(i.ToString()+"@hotmail.com"))
                                          );
                                          
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("123456");
            var students = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, students);
        }
    }
}