using NUnit.Framework;
using PrettifierService;

namespace NUnitTestProject
{
    public class PrettifierTests
    {
        private Prettifier _prettifier;

        [OneTimeSetUp]
        public void Setup()
        {
            _prettifier = new Prettifier();
        }

        [Test]
        public void Prettifier_Should_ReturnAsIsWhenLessThan_SixDigit()
        {
            var input = 89.7;
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(input.ToString(), result);
        }

        [Test]
        public void Prettifier_Should_ReturnMSuffix_NoDecimal_WhenInMillion()
        {
            var input = 100000000;
            var expected = "100M";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void Prettifier_Should_ReturnMSuffix_SingleDecimal_WhenInMillion()
        {
            var input = 1100000;
            var expected = "1.1M";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Prettifier_Should_ReturnMSuffix_SingleDecimal_WhenInMillion_GivenExample()
        {
            var input = 2500000.34;
            var expected = "2.5M";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void Prettifier_Should_ReturnMSuffix_OmitDecimal_WhenInMillion()
        {
            var input = 1000001;
            var expected = "1M";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Prettifier_Should_ReturnTSuffix_OmitDecimal_WhenOverThousandTrillion()
        {
            var input = 2000001000000000;
            var expected = "2000T";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Prettifier_Should_ReturnTSuffix_SingleDecimal_GivenExample()
        {
            var input = 9487634567534;
            var expected = "9.5T";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Prettifier_Should_ReturnBSuffix_OneDecimal_WhenInBillion()
        {
            var input = 1000001000;
            var expected = "1B";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Prettifier_Should_ReturnBSuffix_OneDecimal_WhenInBillion_GivenExample()
        {
            var input = 1123456789;
            var expected = "1.1B";
            var result = _prettifier.Prettify(input);

            Assert.AreEqual(expected, result);
        }
    }
}
