using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;

namespace PrettifierService
{
    public class NumberValidator : INumberValidator
    {
        private readonly List<object> validTypes = new List<object>
            {typeof(Int32), typeof(Int64), typeof(float), typeof(decimal), typeof(long), typeof(double)};
        
        public NumberValidationResponse IsValidNumber<T>(T anything)
        {
            if(validTypes.Contains(anything.GetType()))
            {
                double parsedNumber;
                double.TryParse(anything.ToString(), out parsedNumber);
                if (this.IsNegativeNumber(parsedNumber))
                    return new NumberValidationResponse {Status = GeneralStatus.NegativeNumber};
                return new NumberValidationResponse {Status = GeneralStatus.Success};
            }

            return new NumberValidationResponse {Status = GeneralStatus.NotANumber};
        }

        private bool IsNegativeNumber(double aNumber)  
        {
            return aNumber < 0;
        }
    }
}
