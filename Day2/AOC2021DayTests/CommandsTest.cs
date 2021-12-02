using AOC2021Day2;
using NFluent;
using System.Collections.Generic;
using Xunit;

namespace AOC2021DayTests
{
    public class CommandsTest
    {
        private readonly List<Command> _commandList = new List<Command>
            {
                new Command("forward", 5),
                new Command("down", 5),
                new Command("forward", 8),
                new Command("up", 3),
                new Command("down", 8),
                new Command("forward", 2)
            };
        
        [Fact]
        public void GetFinalPositionTest()
        {
            var commands = new Commands(_commandList);

            var result = commands.GetFinalPosition();
            Check.That(result.Horizon).IsEqualTo(15);
            Check.That(result.Depth).IsEqualTo(10);
            Check.That(result.Horizon*result.Depth).IsEqualTo(150);
        }

        [Fact]
        public void GetFinalCorrectedPositionTest()
        {
            var commands = new CorrectedCommands(_commandList);

            var result = commands.GetFinalPosition();
            Check.That(result.Horizon).IsEqualTo(15);
            Check.That(result.Depth).IsEqualTo(60);
            Check.That(result.Horizon*result.Depth).IsEqualTo(900);
        }
    }
}