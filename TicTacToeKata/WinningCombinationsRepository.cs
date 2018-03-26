using System.Collections.Generic;
using static TicTacToeKata.Square;

namespace TicTacToeKata
{
    public class WinningCombinationsRepository
    {
        private readonly List<List<Square>> _winningCombinationsList;
        private readonly List<Square> _leftColumnCombo = new List<Square>()
        {
            UpperLeft, MiddleLeft, BottomLeft
        };
        private readonly List<Square> _rightColumnCombo = new List<Square>()
        {
            UpperRight, MiddleRight, BottomRight
        };
        private readonly List<Square> _bottomRowCombo = new List<Square>
        {
            BottomRight, BottomCenter, BottomLeft
        };
        private readonly List<Square> _upperRowCombo = new List<Square>
        {
            UpperRight, UpperCenter, UpperLeft
        };
        private readonly List<Square> _middleRowCombo = new List<Square>
        {
            MiddleRight, MiddleCenter, MiddleLeft
        };
        private readonly List<Square> _leftToRightDiagonialCombo = new List<Square>
        {
            UpperLeft, MiddleCenter, BottomRight   
        };
        private readonly List<Square> _rightToLeftDiagonialCombo = new List<Square>
        {
            UpperRight, MiddleCenter, BottomLeft
        };

        public WinningCombinationsRepository()
        {
            _winningCombinationsList = new List<List<Square>>
            {
                _leftColumnCombo, _rightColumnCombo, _bottomRowCombo, _upperRowCombo,
                _middleRowCombo, _leftToRightDiagonialCombo, _rightToLeftDiagonialCombo
            };
        }

        public IEnumerable<List<Square>> Get()
        {
            return _winningCombinationsList;
        }
    }
}