namespace AOC2021Day2
{
    public class CorrectedCommands : ICommands
    {
        public List<Command> CommandList { get; }
        public CorrectedCommands(List<Command> commandList)
        {
            CommandList = commandList;
        }

        public Position GetFinalPosition()
        {
            var horizon = 0;
            var depth = 0;
            var aim = 0;

            foreach (var command in CommandList)
            {
                switch (command.Order)
                {
                    case "forward":
                        horizon += command.Deplacement;
                        depth += command.Deplacement * aim;
                        break;
                    case "down":
                        aim += command.Deplacement;
                        break;
                    case "up":
                        aim -= command.Deplacement;
                        break;
                }
            }

            return new Position(horizon, depth);

        }
    }
}
