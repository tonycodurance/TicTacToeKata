using NUnit.Framework;
using TicTacToeKata;
using static TicTacToeKata.GameState;
using static TicTacToeKata.Square;

namespace TicTacToeKataTests
{
    [TestFixture]
    public class Tests
    {
        private Game _game;
        
        [SetUp]
        public void Init()
        {
            _game = new Game(new WinningCombinationCalculator(new WinningCombinationsRepository()));
        }
        
        [Test]
        public void PlayerXToPlayFirst()
        {
            Assert.True(_game.GetState() == TurnOfX);
        }
        
        [Test]
        public void PlayersCannotPlayOnAnAlreadyPlayedSquare()
        {
            _game.Play(UpperLeft);

            Assert.Throws<SquareAlreadyPlayedException>(() =>
            {
                _game.Play(UpperLeft);
            });
        }

        [TestCase(new[] {
            UpperLeft,
            UpperCenter,
            MiddleLeft,
            UpperRight,
            BottomLeft}, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithAleftColumnWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperRight,
                UpperCenter,
                MiddleRight,
                MiddleCenter,
                BottomRight}, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithArightColumnWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }

        [TestCase(new[] {
                BottomRight,
                UpperCenter,
                BottomCenter,
                MiddleCenter,
                BottomLeft}, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithAbottomRowWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperRight,
                BottomCenter,
                UpperLeft,
                MiddleCenter,
                UpperCenter}, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithAnupperRowWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }

        [TestCase(new[] {
                MiddleCenter,
                BottomCenter,
                MiddleLeft,
                UpperRight,
                MiddleRight
            }, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithAnmiddleRowWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperRight,
                UpperLeft,
                BottomCenter,
                MiddleLeft,
                UpperCenter,
                BottomLeft
            }, 
            OWon)]
        public void ShouldIdentifyAWinOfPlayerOWithAleftColumnWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperLeft,
                UpperRight,
                BottomCenter,
                BottomRight,
                UpperCenter,
                MiddleRight
            }, 
            OWon)]
        public void ShouldIdentifyAWinOfPlayerOWithArightColumnWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }

        [TestCase(new[] {
                UpperLeft,
                BottomCenter,
                UpperRight,
                BottomRight,
                MiddleCenter,
                BottomLeft
            }, 
            OWon)]
        public void ShouldIdentifyAWinOfPlayerOWithAbottomRowWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        
        [TestCase(new[] {
                BottomCenter,
                UpperCenter,
                BottomRight,
                UpperRight,
                MiddleCenter,
                UpperLeft
            }, 
            OWon)]
        public void ShouldIdentifyAWinOfPlayerOWithAnupperRowWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                BottomCenter,
                MiddleCenter,
                BottomRight,
                MiddleRight,
                UpperRight,
                MiddleLeft
            }, 
            OWon)]
        public void ShouldIdentifyAWinOfPlayerOWithAmiddleRowWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                MiddleCenter,
                BottomRight,
                MiddleLeft,
                UpperRight,
                MiddleRight            }, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithAmiddleRowWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperRight,
                UpperLeft,
                MiddleCenter,
                MiddleLeft,
                BottomLeft,
            }, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithARightToLeftDiagonialWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperLeft,
                UpperRight,
                MiddleLeft,
                MiddleCenter,
                BottomRight,
                BottomLeft
            }, 
            OWon)]
        public void ShouldIdentifyAWinOfPlayerOWithARightToLeftDiagonialWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperLeft,
                UpperRight,
                MiddleCenter,
                BottomLeft,
                BottomRight
            }, 
            XWon)]
        public void ShouldIdentifyAWinOfPlayerXWithALeftToRightDiagonialWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        [TestCase(new[] {
                UpperRight,
                UpperLeft,
                MiddleLeft,
                MiddleCenter,
                BottomLeft,
                BottomRight,
            }, 
            OWon)]
        public void ShouldIdentifyAWinOfPlayerOWithALeftToRightDiagonialWinningCombo(Square[] squares, GameState expectedGameState)
        {
            ExecuteTest(squares, expectedGameState);
        }
        
        private void ExecuteTest(Square[] squares, GameState expectedGameState)
        {
            foreach (var position in squares)
            {
                _game.Play(position);
            }

            Assert.AreEqual(_game.GetState(), expectedGameState);
        }
    }
}