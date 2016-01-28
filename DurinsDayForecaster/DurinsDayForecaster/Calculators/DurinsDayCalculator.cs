using DurinsDayForecaster.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DurinsDayForecaster.Calculators
{
    public class DurinsDayCalculator
    {

        // “The first day of the dwarves’ New Year is, as all should know, 
        // the first day of the last moon of Autumn on the threshold of 
        // Winter. We still call it Durin’s Day when the last moon of Autumn 
        // and the sun are in the sky together.But this will not help us 
        // much, I fear, for it passes our skill in these days to guess 
        // when such a time will come again.” – Thorin Oakenshield (The Hobbit)

        // According to the dwarves, the last day of autumn was the
        // beginning of November
        // http://lotr.wikia.com/wiki/Durin's_Day
        
        // First waxing crecsent

        private int _thisYear = DateTime.Today.Year;
        
        public DateTime GetDurinsDay(int? year = null)
        {
            var durinsYear = year ?? _thisYear;

            var beginningOfAutumn = new DateTime(durinsYear, 9, 20); // Doesn't need to be accurate...

            var endOfAutumn = new DateTime(durinsYear, 11, 1);
            
            var fullMoons = GetMoonPhases(beginningOfAutumn, endOfAutumn, MoonPhases.FullMoon);

            return fullMoons.LastOrDefault();
        }

        private IEnumerable<DateTime> GetMoonPhases(DateTime start, DateTime end, double moonPhase)
        {
            var calculator = new MoonPhaseCalculator();

            var nextMoonPhase = start;

            while(nextMoonPhase < end)
            {
                var pivot = nextMoonPhase == start ? nextMoonPhase : nextMoonPhase.AddDays(15);

                nextMoonPhase = calculator.FindNext(pivot, moonPhase);

                if(nextMoonPhase > start && nextMoonPhase < end)
                {
                    yield return nextMoonPhase;
                }
            }
        }
    }
}
