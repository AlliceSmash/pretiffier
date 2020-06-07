using Common.Interfaces;
using System;

namespace PrettifierService
{
    public class Prettifier : INumberPrettifier
    {
        public string Prettify<T>(T number)
        {
            double parsed;
            double.TryParse(number.ToString(), out parsed);

        if (parsed < 1000000.0) return parsed.ToString();

            if (parsed < 1000000000)
            {
                return SimplifyFormat(parsed, 1000000, "M");
            }

            if (parsed < 1000000000000)
            {
                return SimplifyFormat(parsed, 1000000000, "B");
            }

            return SimplifyFormat(parsed, 1000000000000, "T");

        }

        private string SimplifyFormat(double number, long range, string suffix = null)
        {
            var   result = Math.Round(number /range, 1, MidpointRounding.AwayFromZero);
           
            if ( result == (long)(number / range)) result = (long)result;
            return suffix == null
                ? string.Format(result.ToString())
                : string.Format(string.Concat("{0}",suffix), result.ToString());
        }
    }
}
