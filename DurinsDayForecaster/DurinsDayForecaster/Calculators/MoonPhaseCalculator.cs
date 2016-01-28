using DurinsDayForecaster.Extensions;
using System;

namespace DurinsDayForecaster.Calculators
{
    public class MoonPhaseCalculator
    {

        private const double DaysInAYear = 365.25;

        public DateTime FindNext(DateTime date, double moonPhase)
        {
            var jde = MoonPhaseInJDE(date, moonPhase);

            return jde.ToDateTime();
        }

        private double DecimalDate(DateTime date)
        {
            return date.Year + (date.DayOfYear / DaysInAYear);
        }

        private int K(DateTime date)
        {
            return (int) Math.Round((DecimalDate(date) - 2000) * 12.3685);
        }

        private double T(double k)
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
        private double MoonPhaseInJDE(DateTime date, double moonPhase)
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
            // Additional corrections are not included
            // Small inaccuracies will be present

            return jde;
        }
    }
}
