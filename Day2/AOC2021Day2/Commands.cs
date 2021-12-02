namespace AOC2021Day2
{
    public class Commands : ICommands
    {
        public List<Command> CommandList { get; }
        public Commands(List<Command> commandList)
        {
            CommandList = commandList;
        }

        public Position GetFinalPosition()
        {
            var horizon = 0;
            var depth = 0;

            foreach (var command in CommandList)
            {
                switch (command.Order)
                {
                    case "forward":
                        horizon += command.Deplacement;
                        break;
                    case "down":
                        depth += command.Deplacement;
                        break;
                    case "up":
                        depth -= command.Deplacement;
                        break;
                }
            }
            return new Position(horizon, depth);
        }
    }

    public class Position
    {
        public int Horizon;
        public int Depth;

        public Position(int horizon, int depth)
        {
            Horizon = horizon;
            Depth = depth;
        }
    }

    public class Command
    {
        public Command(string order, int deplacement)
        {
            Order = order;
            Deplacement = deplacement;
        }
        public string Order { get; }
        public int Deplacement { get; }
    }
}
