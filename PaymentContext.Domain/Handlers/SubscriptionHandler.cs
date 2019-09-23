using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObject;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository studentRepository,
            IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }
       
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura!!!");
            }
                
            // Verificar se documento já está cadatrado
            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este documento já está em uso!!!");

            // Verificar se os emails estão cadastrados
            if (_studentRepository.DocumentExists(command.Email))
                AddNotification("Email", "Este Email já está em uso!!!");

            // Gravar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var adress = new Adress(command.Street, command.Number, command.Neighborhood,
             command.City, command.State, command.Country,  command.ZipCode);

            // Gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate,
                command.ExpireDate, command.Total, command.TotalPaid, email, command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType), adress);

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, email, document, adress, student, subscription, payment);

            // Salvar as informações
            _studentRepository.CreateSubscription(student);

            // Enviar email de boas vindas
           _emailService.SendEmail(student.Name.ToString(),
            student.Email.Adress, "Bem-vindo ao PaymentContext!", 
            "Pagamento Efetuado! R$100.00"); 

            // Retornar as informações
            new CommandResult(true, "Assinatura realizada com sucesso!!!");
        }
    }
}