using AOC2021Day2;

string[] lines = File.ReadAllLines(@"..\..\..\..\input.txt");

var commandList = new List<Command>();
foreach (var line in lines)
{
    var tab = line.Split(' ');
    var order = tab[0];
    var deplacement = int.Parse(tab[1]);
    commandList.Add(new Command(order, deplacement));
}

Part1(commandList);
Console.WriteLine("");
Part2(commandList);

void Part2(List<Command> commandList)
{
    var commands = new CorrectedCommands(commandList);
    var result = commands.GetFinalPosition();
    Console.WriteLine(result.Horizon * result.Depth);
}

void Part1(List<Command> commandList)
{
    var commands = new Commands(commandList);
    var result = commands.GetFinalPosition();
    Console.WriteLine(result.Horizon * result.Depth);
}