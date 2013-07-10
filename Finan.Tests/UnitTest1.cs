using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finan;
using Moq;

namespace Finan.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string iban = "NL78RABO0162136188";
            var validator = new Validator();

            bool result = validator.Validate(iban);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IbanZonderLandcodeGeeftFalseTerug()
        {
            string iban = "9978RABO0162136188";
            var validator = new Validator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IbanZonderControleCijfersGeeftFalseTerug()
        {
            string iban = "NLXXRABO0162136188";
            var validator = new Validator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IbanZonderBankcodeGeeftFalseTerug()
        {
            string iban = "NL78XXXX0162136188";
            var validator = new Validator();

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        class BankServiceDummy : IBankCodeService
        {
            public bool Contains(string code)
            {
                return false;
            }
        }


        [TestMethod]
        public void IbanMetBankCodeDieWordtAfgekeurdDoorBankServiceGeeftFalseTerug()
        {
            string iban = "NL78RABO0162136188";
            var validator = new Validator(new BankServiceDummy());

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IbanMetBankCodeDieWordtAfgekeurdDoorBankServiceMoqGeeftFalseTerug()
        {
            string iban = "NL78RABO0162136188";

            var service = new Mock<IBankCodeService>();
            service.Setup(
                m => m.Contains(It.IsAny<string>()))
                .Returns(false);

            var validator = new Validator(service.Object);

            bool result = validator.Validate(iban);

            Assert.IsFalse(result);
            service.Verify(m => m.Contains("RABO"));
        }
    }
}
