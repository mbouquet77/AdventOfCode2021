using AOC2021;
using AOC2021Day4;

var aocFiles = new AocFiles();
var input = aocFiles.GetArrayFromFile().ToList();

var bingo = new Bingo(input);
Console.WriteLine(bingo.GetWinningResult());

Console.WriteLine(bingo.GetLastWinningResult());