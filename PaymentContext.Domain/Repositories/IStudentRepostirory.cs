using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string documents);
        bool EmailExists(string documents);
        bool CreateSubscription(Student student);
    }
}