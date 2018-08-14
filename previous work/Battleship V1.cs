using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship_Project
{
    //Anthony Ray
    //Battleship Attempt 
    //Project #1 C#

    class Battleship_Game
    {

        public void DisplayBoard(char[,] Board)
        {
            //Adding a Row and a Column
            int row;
            int column;

            //Grid Layout
            //Added color for amazing graphic visual 1080p!
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  | A B C D E F G H I J ");
            Console.WriteLine("_______________________ ");

            //creates a 10x10 (0-9) grid
            //I'm having trouble substituting X coordinate for letters (a-j) instead of numbers
            //I feel like I would do that by using an array but I can't for the life of me
            //get the syntaxc correct

            for (row = 0; row <= 9; row++)
            {
                Console.Write((row).ToString() + " ¦ ");
                for (column = 0; column <= 9; column++)
                {
                    Console.Write(Board[column, row] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
    }

    class Player
    //Game Play
    {
        public int score = 0;
        char[,] Grid = new char[10, 10];
        public int HitCount = 0;
        public int MissCount = 0;
        int x = 0;
        int y = 0;

        public int getHitCount()
        {
            return HitCount;
        }
        public int countMisses()
        {
            return MissCount;
        }
        public int obtainScore()
        {
            return score;
        }
        public void getCoordinates()
        {
           //Where the user enters their first position
            Console.WriteLine("Enter the X coordinate");
            string line = Console.ReadLine();
            int value;
            if (int.TryParse(line, out value))
            {
                x = value;
            }
            //error catch
            else
            {
                Console.WriteLine("That is not a number");
            }
            //Entering your second coordinate
            Console.WriteLine("Enter the Y coordinate");
            line = Console.ReadLine();
            if (int.TryParse(line, out value))
            {
                y = value;
            }
            //Error catch
            else
            {
                Console.WriteLine("That is not a number.");
            }
            //Hits and Misses
            try
            {
                if (Grid[x, y].Equals(' '))
                {
                    Grid[x, y] = 'H';
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("~~~***Hit***~~~\r\n");
                    Console.ResetColor();
                    HitCount += 1;
                    score += 30;
                }
                else
                {
                    Grid[x, y] = 'M';
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("~~~***Miss***~~~!\r\n");
                    Console.ResetColor();
                    MissCount += 1;
                    score -= 10;
                }
            }
            // if user doesn't enter a number between 1-10
            catch
            {
                Console.Clear();
                Console.WriteLine("Error! You must enter a number between 0 and 9!");
            }
            //Identifies The ships!
        }
        public char[,] GetGrid()
        {
            return Grid;
        }
        public void SetGrid(int q, int w)
        {
            Grid[q, w] = ' ';
        }
        public void computerPosition()
        {
            
            //Minesweeper (2)
            SetGrid(1, 2);
            SetGrid(2, 2);
            //Frigate (3)
            SetGrid(9, 0);
            SetGrid(9, 1);
            SetGrid(9, 2);
            //Frigate # 2 (3)
            SetGrid(2, 5);
            SetGrid(3, 6);
            SetGrid(4, 7);
            //Cruiser (4)
            SetGrid(5, 8);
            SetGrid(6, 8);
            SetGrid(7, 8);
            SetGrid(8, 8);
            //Battleship (5)
            SetGrid(0, 4);
            SetGrid(0, 5);
            SetGrid(0, 6);
            SetGrid(0, 7);
            SetGrid(0, 8);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //intro
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Battleship");
            Console.WriteLine("Please enter your name");
            Console.ResetColor();
            string name = System.Console.ReadLine();
            Console.WriteLine();
            Battleship_Game Board = new Battleship_Game();
            Player Name = new Player();
            Name.computerPosition(); 
            while (Name.getHitCount() < 17)
            {
                //Victory Board
                Board.DisplayBoard(Name.GetGrid());
                Name.getCoordinates();
            }
            Console.Clear(); //clears the board
            Console.BackgroundColor = ConsoleColor.Blue; 
            Console.WriteLine("Congratulations {0}, You are victorious!\r\n", name);
            Console.WriteLine("Total Score: " + Name.obtainScore()); 
            Console.WriteLine("You missed {0} time/times\r\n", Name.countMisses());
            Console.WriteLine("I hope you enjoyed playing Battleship.\n\nPress enter to quit.");
            Console.ResetColor();
            System.Console.ReadLine();
        }
    }
}
