namespace Puzzle15;

public class Display
{
    public static void ShowBoard(int[,] board, int[,] winBoard)
    {
        // Rules and manual header 
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("*********************************************************************");
        Console.Write("*    Use cursor control keys      *    Press");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" esc");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" to exit Game       *");
        Console.Write("*  (the arrows) to move blocks    *     Press");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" N");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" for New Game        *");
        Console.WriteLine("*********************************************************************");


        
        
        // body gameBoard
        for (int l = 0; l < 4; l++)
        {
            
            for (int i = 0; i < NummbersDictionary.Numbers.GetLength(1); i++)
            {
                
                    for (int n = 0; n < board.GetLength(1); n++)
                    {
                        Console.Write($"*  ");
                        
                        Console.ForegroundColor =
                            board[l, n] == winBoard[l, n] ? ConsoleColor.Green : ConsoleColor.Yellow;

                        
                        Console.Write($"{NummbersDictionary.Numbers[board[l, n], i]} ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    Console.Write($"*  ");
                

                Console.WriteLine();
            }

            Console.WriteLine("*********************************************************************");
        }
    }

    //footer win
    public static void ShowWin() 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("*   ██╗██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗██╗    *");
        Console.WriteLine("*   ██║╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║██║    *");
        Console.WriteLine("*   ██║ ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║██║    *");
        Console.WriteLine("*   ╚═╝  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║╚═╝    *");
        Console.WriteLine("*   ██╗   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║██╗    *");
        Console.WriteLine("*   ╚═╝   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝    *");
        Console.WriteLine("*********************************************************************");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
    }
}
