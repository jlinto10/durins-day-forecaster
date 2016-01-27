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

        public static DateTime GetDurinsDay(int year)
        {
            var autumnEquinox = new DateTime(year, 9, 20); // Doesn't need to be accurate...

            var winterSolstice = DecemberSolsticeCalculator.FindSolstice(year);

            var firstQuarterMoons = GetMoonPhases(autumnEquinox, winterSolstice, MoonPhases.FirstQuarter);

            return firstQuarterMoons.LastOrDefault();
        }

        public static IEnumerable<DateTime> GetMoonPhases(DateTime start, DateTime end, double moonPhase)
        {
            var nextMoonPhase = start;

            while(nextMoonPhase < end)
            {
                var pivot = nextMoonPhase == start ? nextMoonPhase : nextMoonPhase.AddDays(15);

                nextMoonPhase = MoonPhaseCalculator.FindNext(pivot, moonPhase);

                if(nextMoonPhase > start && nextMoonPhase < end)
                {
                    yield return nextMoonPhase;
                }
            }
        }
    }
}
