//namespace XO.Core.Players
//{
//    public class InstructedComputerPlayer : IPlayer
//    {
//        public InstructedComputerPlayer(IReadOnlyGame game)
//            => this.game = game;

//        public Position ChoosePosition()
//            => ChoosePosition(
//                TryMarkThirdInLine,
//                TryBlockOponnentThirdInLine,
//                TryFork,
//                TryMarkSecondInLine,
//                TryMarkCenter,
//                TryMarkCorner,
//                TryMarkAnyPosition);

//        private Position ChoosePosition(params TryChoosePositionApproach[] approaches)
//        {
//            foreach (var tryChoosePosition in approaches)
//                if (tryChoosePosition(out var choise))
//                    return choise;

//            throw new InvalidOperationException();
//        }

//        private bool TryMarkThirdInLine(out Position choise)
//        {

//        }

//        private Symbol Symbol
//            => game.CurrentSymbol;

//        private IReadOnlyGrid Grid
//            => game.Grid;

//        private readonly IReadOnlyGame game;

//        private delegate bool TryChoosePositionApproach(out Position choise);
//    }
//}
