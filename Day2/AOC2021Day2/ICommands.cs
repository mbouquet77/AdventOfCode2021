namespace AOC2021Day2
{
    public interface ICommands
    {
        List<Command> CommandList { get; }
        Position GetFinalPosition();
    }
}