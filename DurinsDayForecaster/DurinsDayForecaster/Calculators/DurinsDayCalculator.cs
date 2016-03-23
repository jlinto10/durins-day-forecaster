using DurinsDayForecaster.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DurinsDayForecaster.Calculators
{
    public class DurinsDayCalculator
    {
        private const int LunarCycle = 30; // rounding up

        private readonly int _thisYear;

        public DurinsDayCalculator()
        {
            _thisYear = DateTime.Today.Year;
        }

        /// <summary>
        /// Finds Durin's Day for a given year, the current year will be used if the year is not provided.
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns>The date of Durin's Day</returns>
        public DateTime DurinsDay(int? year = null)
        {
            var y = year ?? _thisYear;
            
            var endOfAutumn = new DateTime(y, 11, 1);

            var start = endOfAutumn.AddDays(-1 * LunarCycle);

            var newMoons = GetMoonPhases(start, endOfAutumn, MoonPhases.NewMoon);

            return newMoons.LastOrDefault();
        }

        /// <summary>
        /// Returns the dates at which a moon phase will occur, whitin a range.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="moonPhase"></param>
        /// <returns></returns>
        private IEnumerable<DateTime> GetMoonPhases(DateTime start, DateTime end, double moonPhase)
        {
            var calculator = new MoonPhaseCalculator();
            
            var nextMoonPhase = calculator.FindNext(start, moonPhase);

            while (nextMoonPhase < end)
            {
                yield return nextMoonPhase;

                nextMoonPhase = calculator.FindNext(nextMoonPhase.AddDays(LunarCycle / 2), moonPhase);
            }
        }
    }
}
