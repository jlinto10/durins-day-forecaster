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
        public void In_2014_durins_day_should_be_october_23rd()
        {
            var durinsDay = new DurinsDayCalculator().DurinsDay(2014);

            Assert.Equal(durinsDay, new DateTime(2014, 10, 23));
        }
    }
}
