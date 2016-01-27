using System;

namespace DurinsDayForecaster.Calculators
{
    public class DecemberSolsticeCalculator
    {

        /// <summary>
        /// Uses simple fromula from the following
        /// http://www.chinaculture.org/focus/focus/2010dongzhi/2010-12/22/content_402208.htm
        /// Only works for the 20th and 21st centuries
        /// Let's be honest this isn't the best formula
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FindSolstice(int year)
        {
            var Y = year - 2000;
            var D = 0.2422;
            var L = Y / 4;

            // C is century, I have no idea where this comes from. Maybe a table?
            var C = (year < 2000) ? 22.6 : 21.94;

            var day = (int)((Y * D) + C) - L;

            return new DateTime(year, 12, day);
        }
    }
}
