// See https://aka.ms/new-console-template for more information
namespace GameProject
{
    interface Program
    {
        static void Main()
        {
            List<List<int>> board = CreateNewBoard();
            
            WriteNewNumber(board);

            WriteCurrentBoard(board);
            
        }

        static void WriteCurrentBoard(List<List<int>> board)
        {
            for(int i = 0; i < board.Count(); i++)
            {
                for(int j = 0; j < board[i].Count(); j++)
                {
                    Console.Write(board[i][j]);
                }
                Console.WriteLine();
            }
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


