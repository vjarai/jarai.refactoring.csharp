using System;
using System.Linq;

namespace Jarai.Refactoring.TicTacToe.Refactored.Logic
{
    public class TicTacToeBoard
    {
        private readonly Player[] _fields = new Player[9];

        private readonly int[][] _winningKombinations =
        {
            // Waagrecht
            new[] { 0, 1, 2 },
            new[] { 3, 4, 5 },
            new[] { 6, 7, 8 },

            // Senkrecht
            new[] { 0, 3, 6 },
            new[] { 1, 4, 7 },
            new[] { 2, 5, 8 },

            // Diagonal
            new[] { 0, 4, 8 },
            new[] { 2, 4, 6 }
        };


        public TicTacToeBoard()
        {
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < _fields.Length; i++)
            {
                _fields[i] = Player.None;
            }
        }

        public char GetFieldSymbol(int fieldNumber)
        {
            return " XO"[(int)_fields[fieldNumber]];
        }

        public bool HasPlayerWon(Player player)
        {
            for (var row = 0; row < _winningKombinations.Length; row++)
            {
                if (_winningKombinations[row].All(x => _fields[x] == player))
                    return true;
            }

            return false;
        }

        public bool IsFieldEmpty(int fieldNumber)
        {
            return _fields[fieldNumber - 1] == Player.None;
        }

        public void SetField(int fieldNumber, Player player)
        {
            if (!IsFieldnumberValid(fieldNumber)) throw new Exception("Wrong selection entered!\nPress any key to try again..");

            if (!IsFieldEmpty(fieldNumber)) throw new Exception("Error: box not vacant!\nPress any key to try again..");

            _fields[fieldNumber - 1] = player;
        }

        public bool IsFieldnumberValid(int fieldNumber)
        {
            return fieldNumber >= 1 && fieldNumber <= _fields.Length;
        }
    }
}