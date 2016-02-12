using DurinsDayForecaster.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{

    public class DurinsDayCalculatorTests
    {
        
        [Fact]
        public void Test_durins_day_this_year()
        {
            var year = DateTime.Today.Year;

            var calc = new DurinsDayCalculator();

            var durinsDay = calc.DurinsDay(year);

            Assert.True(durinsDay.Year == year);
        }

        [Fact]
        public void In_2014_durins_day_should_be_october_23rd()
        {
            var durinsDay = new DurinsDayCalculator().DurinsDay(2014);

            Assert.Equal(durinsDay, new DateTime(2014, 10, 23));
        }

        [Fact]
        public void Test_durins_day_2024()
        {
            var year = 2024;

            var calc = new DurinsDayCalculator();

            var durinsDay = calc.DurinsDay(year);

            Assert.True(durinsDay.Year == year);
        }

        [Fact]
        public void Can_generate_100_years_of_durins_days()
        {
            var year = DateTime.Today.Year;
            var calc = new DurinsDayCalculator();

            for (int i = 0; i < 100; i++, year++)
            {
                var durinsDay = calc.DurinsDay(year);

                Assert.NotEqual(durinsDay, default(DateTime));

                Assert.Equal(year, durinsDay.Year);

                Assert.Equal(durinsDay.Month, 10);
            }
        }
    }
}
