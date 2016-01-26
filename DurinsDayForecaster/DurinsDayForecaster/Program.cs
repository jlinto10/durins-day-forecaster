using System;

namespace DurinsDayForecaster
{
    class Program
    {

        private const double DaysInAYear = 365.25;

        static void Main(string[] args)
        {
            var decimalDate = DecimalDate(new DateTime(2016, 2, 14));

            var testDate = new DateTime(2016, 2, 1);

            var k = K(testDate);

            var jde = MoonPhaseInJDE(testDate, MoonPhases.FullMoon);

            var result = JdeToDateTime(jde);
        }

        static double DecimalDate(DateTime date)
        {
            return date.Year + (date.DayOfYear / DaysInAYear);
        }

        static int K(DateTime date)
        {
            return (int)Math.Round((DecimalDate(date) - 2000) * 12.3685);
        }

        static double T(double k)
        {
            return k / 1236.85;
        }

        /// <summary>
        /// Astronomical Algorithms by Jean Meeus
        /// Page 319 (165 pdf)
        /// </summary>
        /// <param name="date"></param>
        /// <param name="moonPhase"></param>
        /// <returns></returns>
        static double MoonPhaseInJDE(DateTime date, double moonPhase)
        {
            var k = K(date) + moonPhase;

            var t = T(k);

            var t2 = Math.Pow(t, 2);
            var t3 = Math.Pow(t, 3);
            var t4 = Math.Pow(t, 4);

            var jde = 2451550.09765 + 29.530588853 * k
                + 0.0001337 * t2
                - 0.000000150 * t3
                + 0.00000000073 * t4;

            // WARNING
            // Additional corrections are not currently included

            return jde;
        }

        /// <summary>
        /// Source: Astronomical Algorithms by Jean Meeus 
        /// Page 63 (35 in pdf)
        /// </summary>
        /// <param name="jde"></param>
        /// <returns></returns>
        private static DateTime JdeToDateTime(double jde)
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

    public struct MoonPhases
    {
        public const double NewMoon = 0.0;
        public const double FirstQuarter = 0.25;
        public const double FullMoon = 0.5;
        public const double LastQuarter = 0.75;
    }
}
