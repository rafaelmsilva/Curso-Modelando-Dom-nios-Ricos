using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects {
    [TestClass]
    public class DocumentTests {
        //Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid () {
            var doc = new Document ("123", EDocumentType.CNPJ);
            Assert.IsTrue (doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsInvalid () {
            var doc = new Document ("34110468000150", EDocumentType.CNPJ);
            Assert.IsTrue (doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid () {
            var doc = new Document("123",EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCPFIsInvalid () {
            var doc = new Document("12345678909",EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }

    }
}