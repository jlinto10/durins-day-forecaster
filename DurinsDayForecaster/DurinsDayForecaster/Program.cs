using DurinsDayForecaster.Calculators;
using System;

namespace DurinsDayForecaster
{
    class Program
    {

        static void Main(string[] args)
        {

            var durinsDay = DurinsDayCalculator.GetDurinsDay(DateTime.Today.Year);

        }

    }
}
