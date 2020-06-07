using Common.Models;

namespace Common.Interfaces
{
    public interface INumberValidator
    {
        public NumberValidationResponse IsValidNumber<T>(T anything);
    }
}
