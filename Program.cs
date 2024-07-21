// See https://aka.ms/new-console-template for more information
using System.Numerics;

namespace GameProject
{
    interface Program
    {
        static void Main()
        {
            List<List<int>> board = CreateNewBoard();
            
            WriteNewNumber(board);

            WriteCurrentBoard(board);

            while(true)
            {
                var command = Console.ReadKey().Key;

                switch(command)
                {
                    case ConsoleKey.W:
                        EverythingUp(board);
                        break;
                    case ConsoleKey.D:
                        EverythingRight(board);
                        break;
                    case ConsoleKey.S:
                        EverythingDown(board);
                        break;
                    case ConsoleKey.A:
                        EverythingLeft(board);
                        break;
                }
                WriteCurrentBoard(board);
            }
            
        }

        static void EverythingUp(List<List<int>> board)
        {
            for(int i = 1; i < board.Count(); i++)
            {
                for(int j = 0; j < board.Count(); j++)
                {
                    for(int z = 1; z < i+1; z++)
                    {
                        //Console.WriteLine(z);
                        if(board[i][j] == board[i-z][j])
                        {
                            
                            board[i-z][j] += board[i][j];
                            board[i][j] = 0;
                        }
                        else if(board[i-z][j] == 0)
                        {
                            board[i-z][j] = board[i][j];
                            board[i][j] = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            WriteNewNumber(board);
        }
        static void EverythingRight(List<List<int>> board)
        {
            Console.WriteLine();
            for(int i = 0; i < board.Count(); i++)
            {
                for(int j = board.Count() - 2; j > 0; j--)
                {
                    for(int z = 1; z < j; z++)
                    {
                        //Console.WriteLine(z);
                        if(board[i][j] == board[i][j+1])
                        {
                            board[i][j+1] += board[i][j];
                            board[i][j] = 0;
                        }
                        else if(board[i][j+1] == 0)
                        {
                            board[i][j+1] = board[i][j];
                            board[i][j] = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            WriteNewNumber(board);
        }
        static void EverythingDown(List<List<int>> board)
        {
            Console.WriteLine();
            for(int i = board.Count() - 2; i >= 0; i--)
            {
                for(int j = 0; j < board.Count(); j++)
                {
                    for(int z = 1; z < board.Count - i; z++)
                    {
                        Console.WriteLine(z);
                        if(board[i][j] == board[i+z][j])
                        {
                            board[i+z][j] += board[i][j];
                            board[i][j] = 0;
                        }
                        else if(board[i+z][j] == 0)
                        {
                            board[i+z][j] = board[i][j];
                            board[i][j] = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            WriteNewNumber(board);
        }
        static void EverythingLeft(List<List<int>> board)
        {
            Console.WriteLine();
            for(int i = 0; i < board.Count(); i++)
            {
                for(int j = 1; j < board.Count(); j++)
                {
                    if(board[i][j] == board[i][j-1])
                    {
                        board[i][j-1] += board[i][j];
                        board[i][j] = 0;
                    }
                    else if(board[i][j-1] == 0)
                    {
                        board[i][j-1] = board[i][j];
                        board[i][j] = 0;
                    }
                }
            }
            WriteNewNumber(board);
        }
        static void WriteCurrentBoard(List<List<int>> board)
        {
            Console.WriteLine();
            for(int i = 0; i < board.Count(); i++)
            {
                for(int j = 0; j < board[i].Count(); j++)
                {
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("///////////////////");
        }
        static List<List<int>> CreateNewBoard()
        {   
            List<List<int>> board = new List<List<int>>(4);

            for(int i = 0; i < 4; i++)
            {
                List<int> list = new List<int>(4);

                for(int j = 0; j < 4; j++)
                {
                    list.Add(0);
                }
                board.Add(list);
            }
            return board;
        }
        static void WriteNewNumber(List<List<int>> board)
        {
            List<int> NewTile = CheckIfEmpty(board);
            Random rand = new Random();
            int newNumber = rand.Next(2,5);

            while(newNumber == 3)
            {
                newNumber = rand.Next(2,5);
            }

            board[NewTile[0]][NewTile[1]] = newNumber;
        }

        
        static List<int> NewRandomNumber ()
        {
            List<int> list = new List<int>();

            Random rnd = new Random();

            list.Add(rnd.Next(0,3));
            list.Add(rnd.Next(0,3));

            return list;
        }

        static List<int> CheckIfEmpty (List<List<int>> board)
        {
            bool isEmpty = false;
            List<int> list = NewRandomNumber();


            while(isEmpty == false)
            {
                if(board[list[0]][list[1]] == 0)
                {
                    isEmpty = true;
                }
            
                else
                {
                    list = NewRandomNumber();
                }
            }
            return list;
        }
    }
}


