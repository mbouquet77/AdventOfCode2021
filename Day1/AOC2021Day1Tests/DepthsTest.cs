using AOC2021Day1;
using NFluent;
using System.Collections.Generic;
using Xunit;

namespace AOC2021Day1Tests
{
    public class DepthsTest
    {
        private readonly List<int> _depthsList = new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [Fact]
        public void ExampleTestPart1()
        {
            var depths = new Depths(_depthsList);
            Check.That(depths.CountDepthIncrement()).IsEqualTo(7);
        }

        [Fact]
        public void ExampleTestPart2()
        {
            var depths = new Depths(_depthsList);
            Check.That(depths.CountDepthIncrementWithThreeMeasurementWindow()).IsEqualTo(5);
        }
    }
}