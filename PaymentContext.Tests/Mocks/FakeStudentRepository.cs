using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public bool CreateSubscription(Student student)
        {
            return true;
        }

        public bool DocumentExists(string documents)
        {
            if (documents == "9999999999")
                return true;
            return false;
        }

        public bool EmailExists(string documents)
        {
            if (documents == "brunoog33@hotmail.com")
                return true;
            return false;
        }
    }
}