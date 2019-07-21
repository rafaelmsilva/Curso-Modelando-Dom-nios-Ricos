using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entites;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Email _email;
        public StudentTests()
        {
            _name = new Name("Rafael", "Silva");
            _document = new Document("12345678909", EDocumentType.CPF);
            _email = new Email("rafael@teste.com");
            _student = new Student(_name, _document, _email);
            var address = new Address("Rua dois", "123", "Bairro", "BH", "MG", "BR", "30720492");
            _subscription = new Subscription(null, null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenActiveSubscriptions()
        {
            var payment = new PaypalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Rafael", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenNoActiveSubscriptions()
        {
            var payment = new PaypalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Rafael", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
    }
}