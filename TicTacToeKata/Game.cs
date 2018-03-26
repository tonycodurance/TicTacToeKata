using static TicTacToeKata.GameState;

namespace TicTacToeKata
{
    public class Game
    {
        private const int TotalNumberOfSquares = 9;
        private const int MinimumNumberOfTurnsForAWin = 5;
        
        private readonly WinningCombinationCalculator _winningCombinationCalculator;
        private readonly PlayedSquares _squaresPlayedByX, _squaresPlayedByO;
        private GameState _gameState;
        
        public GameState GetState() => _gameState;

        public Game(WinningCombinationCalculator winningCombinationCalculator)
        {
            _gameState = TurnOfX;            
            _winningCombinationCalculator = winningCombinationCalculator;
            _squaresPlayedByX = new PlayedSquares();
            _squaresPlayedByO = new PlayedSquares();
        }

        public void Play(Square square)
        {
            if (SquareAlreadyPlayed(square))
                throw new SquareAlreadyPlayedException();

            UpdateSquares(square);

            if (ThereIsAWinner())
                return;

            if (WeHaveADraw())
            {
                _gameState = Draw;
            }
        }

        private bool WeHaveADraw()
        {
            return GetTotalNumberOfTurns() == TotalNumberOfSquares;
        }

        private void UpdateSquares(Square square)
        {
            var playerXJustPlayed = GetTotalNumberOfTurns() % 2 == 0;
            if (playerXJustPlayed)
            {
                _squaresPlayedByX.Add(square);
            }
            else
            {
                _squaresPlayedByO.Add(square);
            }
        }

        private int GetTotalNumberOfTurns()
        {
            return _squaresPlayedByX.GetCount() + _squaresPlayedByO.GetCount();
        }

        private bool SquareAlreadyPlayed(Square square)
        {
            return _squaresPlayedByX.Contains(square) || _squaresPlayedByO.Contains(square);
        }

        private bool ThereIsAWinner()
        {
            var gameEligibleToHaveWinner = GetTotalNumberOfTurns() >= MinimumNumberOfTurnsForAWin;
            if (gameEligibleToHaveWinner)
            {
                if (_winningCombinationCalculator.WinFoundFor(_squaresPlayedByX))
                {
                    _gameState = XWon;
                    return true;
                }
                
                if (_winningCombinationCalculator.WinFoundFor(_squaresPlayedByO))
                {
                    _gameState = OWon;
                    return true;
                }
            }
            
            return false;
        }
    }
}