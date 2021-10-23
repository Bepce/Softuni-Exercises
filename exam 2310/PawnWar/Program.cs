using System;
using System.Collections.Generic;

namespace Exam23Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];

            char[] boardLetters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };


            //coords
            int wX = -1;
            int wY = -1;
            int bX = -1;
            int bY = -1;

            //GameOver cases
            bool whiteWin = false;
            bool whiteQueen = false;
            bool blackWin = false;
            bool blackQueen = false;
            

            //Fill the board
            for (int i = 0; i < 8; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = input[j];
                    if (input[j] == 'w')
                    {
                        wX = i;
                        wY = j;
                    }
                    if (input[j] == 'b')
                    {
                        bX = i;
                        bY = j;
                    }
                }
            }

            while (!GameOver(whiteWin, whiteQueen, blackWin, blackQueen))
            {
                //move white

                //checks if white can take black
                if (CheckIfBlackNearBy(wX, wY, bX, bY))
                {
                    whiteWin = true;
                    break;
                }

                board[wX, wY] = '-';
                wX--;
                board[wX, wY] = 'w';
                if (wX == 0)
                {
                    whiteQueen = true;
                    break;
                }


                //move black

                //checks if black can take white
                if (CheckIfWhiteNearBy(wX,wY,bX,bY))
                {
                    blackWin = true;
                    break;
                }

                board[bX, bY] = '-';
                bX++;
                board[bX, bY] = 'b';
                if (bX == 7)
                {
                    blackQueen = true;
                    break;
                }
            }
            if (whiteWin)
            {
                Console.WriteLine($"Game over! White capture on {boardLetters[bY]}{Math.Abs(bX - 8)}.");
            }
            else if (blackWin)
            {
                Console.WriteLine($"Game over! Black capture on {boardLetters[wY]}{Math.Abs(wX - 8)}.");
            }
            else if (whiteQueen)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {boardLetters[wY]}{Math.Abs(wX - 8)}.");
            }
            else if (blackQueen)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {boardLetters[bY]}{Math.Abs(bX - 8)}.");
            }
        }

        private static bool CheckIfWhiteNearBy(int wX, int wY, int bX, int bY)
        {
            if ((wX == bX + 1 && wY == bY - 1) || (wX == bX + 1 && wY == bY + 1) || (wX == bX - 1 && wY == bY - 1) || (wX == bX - 1 && wY == bY + 1))
            {
                return true;
            }
            return false;
        }

        private static bool CheckIfBlackNearBy(int wX, int wY, int bX, int bY)
        {
            if ((wX+1 == bX && wY + 1== bY) || (wX + 1 == bX && wY - 1 == bY) || (wX - 1 == bX && wY + 1 == bY) || (wX - 1 == bX && wY - 1 == bY))
            {
                return true;
            }
            return false;
        }

        private static bool GameOver(bool whiteWin, bool whiteQueen, bool blackWin, bool blackQueen)
        {
            if (whiteWin == true || whiteQueen == true || blackWin == true || blackQueen == true)
            {
                return true;
            }
            return false;
        }
    }
}
