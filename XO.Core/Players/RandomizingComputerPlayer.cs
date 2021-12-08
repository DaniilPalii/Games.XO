using XO.SystemExtensions;

namespace XO.Core.Players
{
    public class RandomizingComputerPlayer : IPlayer
    {
        public RandomizingComputerPlayer(IReadOnlyGame game)
            => this.game = game;

        public Position ChoosePosition()
        {
            var availablePositions = game.Grid.FreePositions.ToList();

            return random.Next(availablePositions);
        }

        private readonly IReadOnlyGame game;
        private readonly Random random = new();
    }
}
