using AOC2021Day3;

string[] lines = File.ReadAllLines(@"..\..\..\..\input.txt");

Part1(lines.ToList());
Console.WriteLine("");
Part2(lines.ToList());

void Part1(List<string> inputData)
{
    var powerConsumption = new PowerConsumption(inputData);
    var gammaRate = powerConsumption.GetGammaRate();
    var epsilonRate = powerConsumption.GetEpsilonRate();   
    Console.WriteLine(gammaRate * epsilonRate);
}



void Part2(List<string> inputData)
{
    var powerConsumption = new PowerConsumption(inputData);
    var oxygenRating = powerConsumption.GetOxygenGeneratorRating();
    var co2Rating = powerConsumption.GetCo2ScrubberRating();
    Console.WriteLine(oxygenRating * co2Rating);
}