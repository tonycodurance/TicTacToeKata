using System.Linq;

namespace TicTacToeKata
{
    public class WinningCombinationCalculator
    {
        private readonly WinningCombinationsRepository _winningCombinationsRepository;

        public WinningCombinationCalculator(WinningCombinationsRepository winningCombinationsRepository)
        {
            _winningCombinationsRepository = winningCombinationsRepository;
        }

        public bool WinFoundFor(PlayedSquares squaresPlayed)
        {
            return _winningCombinationsRepository.Get()
                .Select(
                    list => list.Intersect(squaresPlayed.GetSquaresPlayed()).Count() == list.Count()
                ).Any(winningComboFoundInPlayedSquares => winningComboFoundInPlayedSquares);
        }
    }
}