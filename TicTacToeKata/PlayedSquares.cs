using System.Collections.Generic;

namespace TicTacToeKata
{
    public class PlayedSquares
    {
        private readonly List<Square> _squaresPlayed;

        public PlayedSquares()
        {
            _squaresPlayed = new List<Square>();
        }

        public IEnumerable<Square> GetSquaresPlayed() => _squaresPlayed;
        public int GetCount() => _squaresPlayed.Count;
        public void Add(Square square) => _squaresPlayed.Add(square);
        public bool Contains(Square square) => _squaresPlayed.Contains(square);
    }
}