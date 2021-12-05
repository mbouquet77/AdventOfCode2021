using AOC2021Day3;
using NFluent;
using System.Collections.Generic;
using Xunit;

namespace AOC2021Day3Tests
{
    public class PowerConsumptionTest
    {
        [Fact]
        public void Test1()
        {
            var inputData = new List<string>
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            var result = new PowerConsumption(inputData);

            Check.That(result.GetGammaRate()).IsEqualTo(22);
            Check.That(result.GetEpsilonRate()).IsEqualTo(9);
            Check.That(result.GetOxygenGeneratorRating()).IsEqualTo(23);
            Check.That(result.GetCo2ScrubberRating()).IsEqualTo(10);
        }
    }
}