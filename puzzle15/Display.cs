namespace puzzle15;

public class Display
{
    public static void ShowBoard(int [,] board, int [,] winboard)
        {  
            // Rules and manual
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
            
            
            /*
            4 lines of 4 digits per digit 6 lines per line 13 characters
            there are 3 arrays:
                1) the array in which we play board [l, n] 4x4
                2) array with which we compare winboard [l, n] 4x4 for coloring
                    in green if the number is in its place
                    or yellow if not on your own
                3) character array NummbersDictionary.Number [,,] from where we take the characters
            */
            
            
            // l(0-3) row in a 4x4 grid displayed to the user in the console
            for (int l = 0; l < 4; l++)
            {   
                // i (0-6) draw character string NummbersDictionary.Numbers
                for (int i = 0; i < NummbersDictionary.Numbers.GetLength(1); i++)
                {  //j(0-13) drawing character symbol NummbersDictionary.Numbers
                    for (int j = 0; j < NummbersDictionary.Numbers.GetLength(2); j++)
                    {   // n(0-3) a column in a 4x4 grid displayed to the user in the console
                        for (int n = 0; n < board.GetLength(1); n++)
                        {
                            Console.Write($"*  ");
                            // if the element is in its place, paint it green; if not, paint it yellow
                            Console.ForegroundColor = board[l, n] == winboard[l, n] ? ConsoleColor.Green : ConsoleColor.Yellow;
                            
                            // extract the element numbered board[l, n] from NummbersDictionary.Numbers and write the character to the console
                            Console.Write($"{NummbersDictionary.Numbers[board[l, n], i, j]} ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.Write($"*  ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("*********************************************************************");
            }
        }

    public static void Showwin()
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









/*public string[,] Canvas = new string[160, 160];

public int[,] Canvascollor = new int[160, 160];

public void Fillcanvas()
{
    for (int i = 0; i < Canvas.GetLength(0); i++) {
        for (int j = 0; j < Canvas.GetLength(1); j++)
        {
            Canvas[i, j] = "*";
        }
    }
}

public void Showcanvas()
{
    for (int i = 0; i < Canvas.GetLength(0); i++) {
        for (int j = 0; j < Canvas.GetLength(1); j++)
        {
            Console.Write(Canvas[i, j]);
        }
        Console.WriteLine();
    }
}

public void Showboard(int[,] board, int[,] winboard)
{

    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 13; j++)
        {
            Canvas[i, j] = NummbersDictionary.Numbers[1, i, j];
        }
    }
}*/
