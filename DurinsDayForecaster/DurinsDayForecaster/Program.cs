using DurinsDayForecaster.Calculators;
using DurinsDayForecaster.Structs;
using System;

namespace DurinsDayForecaster
{
    class Program
    {

        static void Main(string[] args)
        {
            var date = new DateTime(2016, 2, 1);
        
            var nextFullMoon = MoonPhaseCalculator.FindNext(date, MoonPhases.FullMoon);

            var decemberSolstice = DecemberSolsticeCalculator.FindSolstice(date);
        }

    }
}
