using System.Threading;

namespace Jarai.Refactoring.TicTacToe.Step2
{
    public class TicTacToeGame
    {

        public TicTacToeGame(IUserInterface userInterface)
        {
            Console = userInterface;
        }

        public IUserInterface Console { get; set; }

        public char Box1 { get; set; }

        public char Box2 { get; set; }

        public char Box3 { get; set; }

        public char Box4 { get; set; }

        public char Box5 { get; set; }

        public char Box6 { get; set; }

        public char Box7 { get; set; }

        public char Box8 { get; set; }

        public char Box9 { get; set; }

        public bool Error { get; set; }

        public bool IsWin { get; set; }

        public bool IsY { get; set; }

        public char WinPerson { get; set; }

        public void CheckWin()
        {
            // 123, 456, 789, 147, 258, 369, 159, 357
            if (Box1 == 'X' && Box2 == 'X' && Box3 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            }

            if (Box4 == 'X' && Box5 == 'X' && Box6 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            }

            if (Box7 == 'X' && Box8 == 'X' && Box9 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            }

            if (Box1 == 'X' && Box4 == 'X' && Box7 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            }

            if (Box2 == 'X' && Box5 == 'X' && Box8 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            }

            if (Box3 == 'X' && Box6 == 'X' && Box9 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            } // 159, 357

            if (Box1 == 'X' && Box5 == 'X' && Box9 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            }

            if (Box3 == 'X' && Box5 == 'X' && Box7 == 'X')
            {
                IsWin = true;
                WinPerson = 'X';
                return;
            }

            if (Box1 == 'Y' && Box2 == 'Y' && Box3 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
                return;
            }

            if (Box4 == 'Y' && Box5 == 'Y' && Box6 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
                return;
            }

            if (Box7 == 'Y' && Box8 == 'Y' && Box9 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
                return;
            }

            if (Box1 == 'Y' && Box4 == 'Y' && Box7 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
                return;
            }

            if (Box2 == 'Y' && Box5 == 'Y' && Box8 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
                return;
            }

            if (Box3 == 'Y' && Box6 == 'Y' && Box9 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
                return;
            } // 159, 357

            if (Box1 == 'Y' && Box5 == 'Y' && Box9 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
                return;
            }

            if (Box3 == 'Y' && Box5 == 'Y' && Box7 == 'Y')
            {
                IsWin = true;
                WinPerson = 'Y';
            }
        }

        public void DisplayLoss()
        {
            Console.WriteLine();
            Console.WriteLine("No one won.");
            Console.ReadKey();
        }

        public void NotVacantError()
        {
            Error = true;
            Console.WriteLine();
            Console.WriteLine("Error: box not vacant!");
            Console.WriteLine("Press any key to try again..");
            Console.ReadKey();
        }

        public void WriteBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", Box1, Box2, Box3);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", Box4, Box5, Box6);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", Box7, Box8, Box9);
        }

        public void Play()
        {
            var moveCount = 0; // check loss
            char askMove; // display X or Y in question
            int selTemp;
            var prog = this;
            prog.Error = false;
            prog.Box1 = ' ';
            prog.Box2 = ' ';
            prog.Box3 = ' ';
            prog.Box4 = ' ';
            prog.Box5 = ' ';
            prog.Box6 = ' ';
            prog.Box7 = ' ';
            prog.Box8 = ' ';
            prog.Box9 = ' ';
            prog.IsY = true;
            Console.WriteLine(" -- Tic Tac Toe -- ");
            Thread.Sleep(1200);
            Console.Clear();
            while (!prog.IsWin)
            {
                if (moveCount == 9)
                {
                    prog.DisplayLoss();
                    break;
                }
                if (prog.IsY) // if is X
                    askMove = 'X';
                else
                    askMove = 'Y';
                Console.Clear();
                prog.WriteBoard();
                Console.WriteLine();
                Console.WriteLine("What box do you want to place {0} in? (1-9)", askMove);
                Console.Write("> ");
                selTemp = int.Parse(Console.ReadLine());
                switch (selTemp)
                {
                    case 1:
                        if (prog.Box1 == ' ')
                        {
                            prog.Box1 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 2:
                        if (prog.Box2 == ' ')
                        {
                            prog.Box2 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 3:
                        if (prog.Box3 == ' ')
                        {
                            prog.Box3 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 4:
                        if (prog.Box4 == ' ')
                        {
                            prog.Box4 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 5:
                        if (prog.Box5 == ' ')
                        {
                            prog.Box5 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 6:
                        if (prog.Box6 == ' ')
                        {
                            prog.Box6 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 7:
                        if (prog.Box7 == ' ')
                        {
                            prog.Box7 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 8:
                        if (prog.Box8 == ' ')
                        {
                            prog.Box8 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    case 9:
                        if (prog.Box9 == ' ')
                        {
                            prog.Box9 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }

                        break;
                    default:
                        Console.WriteLine("Wrong selection entered!");
                        Console.WriteLine("Press any key to try again..");
                        Console.ReadKey();
                        prog.Error = true;
                        break;
                }

                if (prog.Error)
                {
                    prog.CheckWin(); // if error, just check win
                    prog.Error = !prog.Error;
                }
                else
                {
                    prog.IsY = !prog.IsY; // flip boolean
                    prog.CheckWin();
                }
            }

            Console.Clear();
            prog.WriteBoard();
            Console.WriteLine();
            Console.WriteLine("The winner is {0}!", prog.WinPerson);
            Console.ReadKey();
        }
    }
}