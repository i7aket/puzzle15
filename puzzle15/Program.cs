// See https://aka.ms/new-console-template for more information
// puzzle15 version 0.1

using System.Threading.Channels;

internal class Program
{
    public static void Main(string[] args)
    
    {
        // The Array for chekking 1. win 2. collors of box.
        int [,] winBoard  =
        {
            {1,2,3,4},
            {5,6,7,8},
            {9,10,11,12},
            {13,14,15,0},
        };    
        
        
        
        // Array for plaing
        int [,] board  =
        {
            {1,2,3,4},
            {5,6,7,8},
            {9,10,11,12},
            {13,14,15,0},
        };
        
        //Posission of Zero
        int PosX = 3;
        int PosY = 3;

        // Dictionary for numbers
        
        
        
        string[,,] numbers = {
            {
                {"             "},
                {"             "},
                {"             "},
                {"             "},
                {"             "},
                {"             "}
            },
            {
                {"     ██╗     "},
                {"    ███║     "},
                {"    ╚██║     "},
                {"     ██║     "},
                {"     ██║     "},
                {"     ╚═╝     "}
            },
            {
                {"  ██████╗    "},
                {"  ╚════██╗   "},
                {"   █████╔╝   "},
                {"  ██╔═══╝    "},
                {"  ███████╗   "},
                {"  ╚══════╝   "}
            },
            {
                {"  ██████╗    "},
                {"  ╚════██╗   "},
                {"   █████╔╝   "},
                {"   ╚═══██╗   "},
                {"  ██████╔╝   "},
                {"  ╚═════╝    "}
            },
            {
                {"  ██╗  ██╗   "},
                {"  ██║  ██║   "},
                {"  ███████║   "},
                {"  ╚════██║   "},
                {"       ██║   "},
                {"       ╚═╝   "}
            },
            {
                {"  ███████╗   "},
                {"  ██╔════╝   "},
                {"  ███████╗   "},
                {"  ╚════██║   "},
                {"  ███████║   "},
                {"  ╚══════╝   "},     
            },
            {
                {"   ██████╗   "},
                {"  ██╔════╝   "},
                {"  ███████╗   "},
                {"  ██╔═══██╗  "},
                {"  ╚██████╔╝  "},
                {"   ╚═════╝   "}
            },
            {
                {"  ███████╗   "},
                {"  ╚════██║   "},
                {"      ██╔╝   "},
                {"     ██╔╝    "},  
                {"     ██║     "},
                {"     ╚═╝     "}       
            },
            {
                {"   █████╗    "},
                {"  ██╔══██╗   "},
                {"  ╚█████╔╝   "},
                {"  ██╔══██╗   "},
                {"  ╚█████╔╝   "},
                {"   ╚════╝    "},      
            },
            {
                {"   █████╗    "},
                {"  ██╔══██╗   "},
                {"  ╚██████║   "},
                {"   ╚═══██║   "},
                {"   █████╔╝   "},
                {"   ╚════╝    "}
            },
            {
                { " ██╗ ██████╗ " },
                { "███║██╔═████╗" },
                { "╚██║██║██╔██║" },
                { " ██║████╔╝██║" },
                { " ██║╚██████╔╝" },
                { " ╚═╝ ╚═════╝ " },
            },
            {
                {"    ██╗ ██╗  "},
                {"   ███║███║  " },
                {"   ╚██║╚██║  "},
                {"    ██║ ██║  " },
                {"    ██║ ██║  "},
                {"    ╚═╝ ╚═╝  "}    
            },
            {
                {" ██╗██████╗  "},
                {"███║╚════██╗ "},
                {"╚██║ █████╔╝ "},
                {" ██║██╔═══╝  "},
                {" ██║███████╗ "},
                {" ╚═╝╚══════╝ "}   
            },
            {
                {" ██╗██████╗  "},
                {"███║╚════██╗ "},
                {"╚██║ █████╔╝ "},
                {" ██║ ╚═══██╗ "},
                {" ██║██████╔╝ "},
                {" ╚═╝╚═════╝  "}  
            },
            {
                {" ██╗██╗  ██╗ "},
                {"███║██║  ██║ "},
                {"╚██║███████║ "},
                {" ██║╚════██║ "},
                {" ██║     ██║ "},
                {" ╚═╝     ╚═╝ "}
            },
            {
                {" ██╗███████╗ "},
                {"███║██╔════╝ "},
                {"╚██║███████╗ "},
                {" ██║╚════██║ "},
                {" ██║███████║ "},
                {" ╚═╝╚══════╝ "} 
            }
        };

        void winCommand()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = winBoard[i, j];
                } 
            }
        }
        
        void newGame()
        {
            PosX = 3;
            PosY = 3;
            
            winCommand();
        }
        
        // drawing the board in console if correct place green if not yellow
        void showBoard()
        {   
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
            for (int l = 0; l < 4; l++)
            {
                for (int i = 0; i < numbers.GetLength(1); i++)
                {
                    for (int j = 0; j < numbers.GetLength(2); j++)
                    {
                        for (int n = 0; n < board.GetLength(1); n++)
                        {
                            Console.Write($"*  ");
                            Console.ForegroundColor = board[l, n] == winBoard[l, n] ? ConsoleColor.Green : ConsoleColor.Yellow;

                            Console.Write($"{numbers[board[l, n], i, j]} ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }

                        Console.Write($"*  ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("*********************************************************************");
            }
        }
        showBoard();

        void moveRight(int a)
        {
            for (int i = 0; i < a; i++)
            {
                board[PosY, PosX] = board[PosY, PosX + 1];
                board[PosY, PosX + 1] = 0;
                PosX++;
                Console.Clear();
                showBoard();
            }
        }

        void moveDown(int a)
        {
            for (int i = 0; i < a; i++)
            {
                board[PosY, PosX] = board[PosY + 1, PosX];
                board[PosY + 1, PosX] = 0;
                PosY++;
                Console.Clear();
                showBoard();
            }
        }

        void moveLeft(int a)
        {
            for (int i = 0; i < a; i++)
            {
                board[PosY, PosX] = board[PosY, PosX - 1];
                board[PosY, PosX - 1] = 0;
                PosX--;
                Console.Clear();
                showBoard();
            }
        }

        void moveUp(int a)
        {
            for (int i = 0; i < a; i++)
            {
                board[PosY, PosX] = board[PosY  - 1, PosX]; 
                board[PosY - 1, PosX] = 0;
                PosY--;
                Console.Clear();
                showBoard();
            }
        }
        
        void shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int rnd = random.Next(1, 4);
                moveUp(rnd);
                moveLeft(rnd);
                moveDown(rnd);
                moveRight(rnd);
            }
        }
        
        newGame();
        shuffle();
        
        ConsoleKeyInfo e;
        do
        {
            e = Console.ReadKey();

            switch (e.Key)
            {
                case ConsoleKey.RightArrow when PosX < 3:
                    moveRight(1);    
                    break;
                
                case ConsoleKey.DownArrow when PosY < 3:
                    moveDown(1);
                    break;
                
                case ConsoleKey.LeftArrow when PosX > 0:
                    moveLeft(1);
                    break;
                
                case ConsoleKey.UpArrow when PosY > 0:
                    moveUp(1);
                    break;
                case ConsoleKey.N:
                    newGame();
                    shuffle();
                    break;
                case ConsoleKey.W:
                    winCommand();
                    Console.Clear();
                    showBoard();
                    break;
                default: break;
            } 
            
            bool win = true;
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j< 4; j++)
                    if (board[i, j] != winBoard[i, j])
                    {
                        win = false;
                        break;
                    }
                if (!win) break;
            }
            if (win == true)
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
                Console.WriteLine("Press enter to start new game");
                Console.ReadLine();
                newGame();
                shuffle();
            }
        }
        while (e.Key != ConsoleKey.Escape);
    }
}


