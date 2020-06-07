using Common.Interfaces;
using Common.Models;
using System;

namespace PrettifierService
{
    public class PerttifierService : IPrettifierService
    {
        private INumberPrettifier _numberPrettifier;
        private INumberValidator _numberValidator;

        public PerttifierService(INumberValidator validator, INumberPrettifier prettifier)
        {
            if (validator == null) throw new InvalidOperationException("Validator has not been instanticated");
            if (prettifier == null) throw new InvalidOperationException("Prettifier has not been instanticated");
            _numberPrettifier = prettifier;
            _numberValidator = validator;
        }

        public PrettifyResponse Prettify<T>(T aNumber)
        {
            var validationStatus = _numberValidator.IsValidNumber(aNumber);
            if (validationStatus.Status != GeneralStatus.Success)
            {
                return new PrettifyResponse
                { StatusMessage = validationStatus.Status.ToString(), PrettifiedResult = string.Empty };
            }

            var result = _numberPrettifier.Prettify(aNumber);
            return new PrettifyResponse { StatusMessage = GeneralStatus.Success.ToString(), PrettifiedResult = result };
        }
    }
}
