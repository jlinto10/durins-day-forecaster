using DurinsDayForecaster.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DurinsDayForecaster.Calculators
{
    public class DurinsDayCalculator
    {
        private const int LunarCycle = 30; // rounding up

        // “The first day of the dwarves’ New Year is, as all should know, 
        // the first day of the last moon of Autumn on the threshold of 
        // Winter. We still call it Durin’s Day when the last moon of Autumn 
        // and the sun are in the sky together.But this will not help us 
        // much, I fear, for it passes our skill in these days to guess 
        // when such a time will come again.” – Thorin Oakenshield (The Hobbit)

        // According to the dwarves, the last day of autumn was the
        // beginning of November
        // http://lotr.wikia.com/wiki/Durin's_Day

        // Let's go with the last new moon of autumn
        // http://askmiddlearth.tumblr.com/post/73200106670/how-to-predict-durins-day

        private readonly int _thisYear;

        public DurinsDayCalculator()
        {
            _thisYear = DateTime.Today.Year;
        }

        public DateTime DurinsDay(int? year = null)
        {
            var y = year ?? _thisYear;
            
            var endOfAutumn = new DateTime(y, 11, 1);

            var start = endOfAutumn.AddDays(-1 * LunarCycle);

            var newMoons = GetMoonPhases(start, endOfAutumn, MoonPhases.NewMoon);

            return newMoons.LastOrDefault();
        }

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
