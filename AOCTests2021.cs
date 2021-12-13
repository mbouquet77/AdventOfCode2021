using AOC2021Day1;
using AOC2021Day2;
using AOC2021Day3;
using AOC2021Day4;
using NFluent;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace AOC2021Tests
{
    public class AOCTests2021
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

        private readonly List<int> _depthsList = new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

        [Fact]
        public void DepthsTestPart1()
        {
            var depths = new Depths(_depthsList);
            Check.That(depths.CountDepthIncrement()).IsEqualTo(7);
        }

        [Fact]
        public void DepthsTestPart2()
        {
            var depths = new Depths(_depthsList);
            Check.That(depths.CountDepthIncrementWithThreeMeasurementWindow()).IsEqualTo(5);
        }
        [Fact]
        public void GetFinalPositionTest()
        {
            var commands = new Commands(_commandList);

            var result = commands.GetFinalPosition();
            Check.That(result.Horizon).IsEqualTo(15);
            Check.That(result.Depth).IsEqualTo(10);
            Check.That(result.Horizon * result.Depth).IsEqualTo(150);
        }

        [Fact]
        public void GetFinalCorrectedPositionTest()
        {
            var commands = new CorrectedCommands(_commandList);

            var result = commands.GetFinalPosition();
            Check.That(result.Horizon).IsEqualTo(15);
            Check.That(result.Depth).IsEqualTo(60);
            Check.That(result.Horizon * result.Depth).IsEqualTo(900);
        }

        [Fact]
        public void PowerConsumptionTest()
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

        [Fact]
        public void BingoTests()
        {
            var input = new List<string>()
            {
"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
"",
"22 13 17 11  0",
" 8  2 23  4 24",
"21  9 14 16  7",
" 6 10  3 18  5",
" 1 12 20 15 19",
"",
" 3 15  0  2 22",
" 9 18 13 17  5",
"19  8  7 25 23",
"20 11 10 24  4",
"14 21 16 12  6",
"",
"14 21 17 24  4",
"10 16 15  9 19",
"18  8 23 26 20",
"22 11 13  6  5",
" 2  0 12  3  7"
            };
            var bingo = new Bingo(input);

            Check.That(bingo.GetDrawList()).IsEqualTo(new int[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 });

            var boardList = bingo.GetBoardList();

            Check.That(boardList.Count).IsEqualTo(3);

            var board1 = boardList[0];
            Check.That(board1).IsEqualTo(new Cell[5, 5]
            {
                { new Cell(22, false), new Cell(13, false), new Cell(17, false), new Cell(11, false), new Cell(0, false) },
                { new Cell(8, false), new Cell(2, false), new Cell(23, false), new Cell(4, false), new Cell(24, false) },
                { new Cell(21, false), new Cell(9, false), new Cell(14, false), new Cell(16, false), new Cell(7, false) },
                { new Cell(6, false), new Cell(10, false), new Cell(3, false), new Cell(18, false), new Cell(5, false) },
                { new Cell(1, false), new Cell(12, false), new Cell(20, false), new Cell(15, false), new Cell(19, false) }
            });

            var board2 = boardList[1];
            Check.That(board2).IsEqualTo(new Cell[5, 5]
            {
                { new Cell(3, false), new Cell(15, false), new Cell(0, false), new Cell(2, false), new Cell(22, false) },
                { new Cell(9, false), new Cell(18, false), new Cell(13, false), new Cell(17, false), new Cell(5, false) },
                { new Cell(19, false), new Cell(8, false), new Cell(7, false), new Cell(25, false), new Cell(23, false) },
                { new Cell(20, false), new Cell(11, false), new Cell(10, false), new Cell(24, false), new Cell(4, false) },
                { new Cell(14, false), new Cell(21, false), new Cell(16, false), new Cell(12, false), new Cell(6, false) }
            });

            var board3 = boardList[2];
            Check.That(board3).IsEqualTo(new Cell[5, 5]
            {
                { new Cell(14, false), new Cell(21, false), new Cell(17, false), new Cell(24, false), new Cell(4, false) },
                { new Cell(10, false), new Cell(16, false), new Cell(15, false), new Cell(9, false), new Cell(19, false) },
                { new Cell(18, false), new Cell(8, false), new Cell(23, false), new Cell(26, false), new Cell(20, false) },
                { new Cell(22, false), new Cell(11, false), new Cell(13, false), new Cell(6, false), new Cell(5, false) },
                { new Cell(2, false), new Cell(0, false), new Cell(12, false), new Cell(3, false), new Cell(7, false) }
            });

            var result = bingo.GetWinningResult();
            Check.That(result).IsEqualTo(4512);

            result = bingo.GetLastWinningResult();
            Check.That(result).IsEqualTo(1924);
        }
    }
}
