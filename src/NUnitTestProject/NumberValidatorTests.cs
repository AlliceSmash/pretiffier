using NUnit.Framework;
using PrettifierService;

namespace NUnitTestProject
{
    public class NumberValidatorTests
    {
        private NumberValidator _numberValidator;

        [OneTimeSetUp]
        public void Setup()
        {
            _numberValidator = new NumberValidator();
        }

        [Test]
        public void Validator_Should_ReturnInvalid_WhenStringInput()
        {
            var input = "hello";
            var result = _numberValidator.IsValidNumber(input);

            Assert.IsTrue(result.Status == Common.Models.GeneralStatus.NotANumber);
        }

        [Test]
        public void Validator_Should_Return_InvalidNumber_WhenNegativeNumber()
        {
            var input = -1;
            var result = _numberValidator.IsValidNumber(input);
            Assert.IsTrue(result.Status == Common.Models.GeneralStatus.NegativeNumber);
        }

        [Test]
        public void Validator_Should_Return_Success_WhenZero()
        {
            var input = 0.0;
            var result = _numberValidator.IsValidNumber(input);
            Assert.IsTrue(result.Status == Common.Models.GeneralStatus.Success);
        }

        [Test]
        public void Validator_Should_Return_Success_WhenPositiveNumber()
        {
            var input = 1000000000000000;
            var result = _numberValidator.IsValidNumber(input);
            Assert.IsTrue(result.Status == Common.Models.GeneralStatus.Success);
        }
    }
}