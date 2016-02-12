using System;

namespace DurinsDayForecaster.Extensions
{
    internal static class AstronomyExtensionscs
    {

        /// <summary>
        /// Source: Astronomical Algorithms by Jean Meeus 
        /// Page 63 (35 in pdf)
        /// </summary>
        /// <param name="jde"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this double jde)
        {
            var jd = jde + .5;

            var z = (int)jd;
            var F = jd - z;

            double A;

            if (z < 2299161)
            {
                A = z;
            }
            else
            {
                var alpha = (int)((z - 1867216.25) / 36524.25);
                A = z + 1 + alpha - ((int)alpha / 4);
            }

            var B = A + 1524;
            var C = (int)((B - 122.1) / 365.25);
            var D = (int)(365.25 * C);
            var E = (int)((B - D) / 30.6001);

            var day = B - D - ((int)(30.6001 * E)) + F;
            var month = (E < 14) ? E - 1 : E - 13;
            var year = (month > 2) ? C - 4716 : C - 4715;

            return new DateTime(year, month, (int)day);
        }
    }
}
