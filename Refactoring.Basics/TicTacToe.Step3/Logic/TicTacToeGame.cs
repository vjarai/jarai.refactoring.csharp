using System;
using Jarai.Refactoring.TicTacToe.Step3.UserInterface;

namespace Jarai.Refactoring.TicTacToe.Step3.Logic
{
    public class TicTacToeGame
    {
        private readonly TicTacToeBoard _board;
        private readonly IUserInterface _userInterface;
        private Player _currentPlayer = Player.X;

        public TicTacToeGame(IUserInterface ui)
        {
            _userInterface = ui;
            _board = new TicTacToeBoard();
        }

        public void Play()
        {
            _userInterface.ShowMessage(" -- Tic Tac Toe -- ");

            var moveCount = 0;

            while (true)
            {
                _userInterface.ShowBoard(_board);

                var move = _userInterface.GetMove(_currentPlayer);

                try
                {
                    _board.SetField(move, _currentPlayer);
                }
                catch (Exception e)
                {
                    _userInterface.ShowMessage(e.Message);
                    continue;
                }

                moveCount++;

                if (_board.HasPlayerWon(_currentPlayer))
                {
                    _userInterface.ShowMessage($"The winner is {_currentPlayer}!");
                    break;
                }

                if (moveCount >= 9)
                {
                    _userInterface.ShowMessage("No one won.");
                    break;
                }

                _currentPlayer = _currentPlayer == Player.O ? Player.X : Player.O;
            }
        }
    }
}