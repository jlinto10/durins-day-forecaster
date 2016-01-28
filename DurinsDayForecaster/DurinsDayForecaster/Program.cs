using DurinsDayForecaster.Calculators;
using System;

namespace DurinsDayForecaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new DurinsDayCalculator();

            var durinsDay = calculator.GetDurinsDay(2017);
        }
    }
}
