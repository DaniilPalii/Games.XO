namespace XO.Core.Players
{
    public class HumanPlayer : IPlayer
    {
        public HumanPlayer(Func<Position> choosePosition)
            => this.choosePosition = choosePosition;

        public Position ChoosePosition()
            => choosePosition();

        private readonly Func<Position> choosePosition;
    }
}
