using Common.Interfaces;
using Common.Models;
using Moq;
using NUnit.Framework;
using PrettifierService;

namespace NUnitTestProject
{
    public class PrettifierServiceTests
    {
        private Mock<INumberPrettifier> _prettifier;
        private Mock<INumberValidator> _validator;
        private IPrettifierService _service;

        [OneTimeSetUp]
        public void Init()
        {
            _validator = new Mock<INumberValidator>() { };
            _prettifier = new Mock<INumberPrettifier>();
            _service = new PerttifierService(_validator.Object, _prettifier.Object);
        }

        [Test]
        public void Service_Should_Return_NotANumberMessage()
        {
            var input = "hi";

            _validator.Setup(r => r.IsValidNumber<string>(It.IsAny<string>())).Returns(new NumberValidationResponse
            { Status = GeneralStatus.NotANumber });

            var result = _service.Prettify(input);
            var expectedMessage = "NotANumber";
            Assert.AreEqual(expectedMessage, result.StatusMessage.ToString());
        }

        [Test]
        public void Service_Should_Return_CorrectMessage()
        {
            var input = 10;
            var expectedString = "10";
            _validator.Setup(r => r.IsValidNumber<int>(It.IsAny<int>())).Returns(new NumberValidationResponse
            { Status = GeneralStatus.Success });

            _prettifier.Setup(r => r.Prettify<int>(It.IsAny<int>())).Returns("10");
            var result = _service.Prettify(input);
            var expectedMessage = "Success";
            Assert.AreEqual(expectedMessage, result.StatusMessage.ToString());
            Assert.AreEqual(expectedString, result.PrettifiedResult);
        }

        [Test]
        public void Service_Should_Return_CorrectMessage_NegativeNumber()
        {
            var input = -10;
            var expectedString = "";
            _validator.Setup(r => r.IsValidNumber<int>(It.IsAny<int>())).Returns(new NumberValidationResponse
            { Status = GeneralStatus.NegativeNumber });

            var result = _service.Prettify(input);
            var expectedMessage = "NegativeNumber";
            Assert.AreEqual(expectedMessage, result.StatusMessage.ToString());
            Assert.AreEqual(expectedString, result.PrettifiedResult);
        }
    }
}
