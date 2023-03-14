// puzzle15 version 0.3

namespace Puzzle15;



internal class Program
{
    public static void Main(string[] args)

    { 
        GameBoard board = new GameBoard();
        
        
        /*Display canvas = new Display();
        canvas.Fillcanvas();*/
        
        

        
        void NewGame()
        {
            board.DefaultPosition();
            Display.ShowBoard(board.Board, board.WinBoard);
        }
        
        Display.ShowBoard(board.Board, board.WinBoard);
        NewGame();
        board.Shuffle();
        Console.Clear();
        Display.ShowBoard(board.Board, board.WinBoard);
        
        ConsoleKeyInfo e;
        do
        {
            e = Console.ReadKey();

            switch (e.Key)
            {
                case ConsoleKey.RightArrow when board.ZeroPosX < 3:
                    board.MoveTile("Right", 1);    
                    break;
                
                case ConsoleKey.DownArrow when board.ZeroPosY < 3:
                    board.MoveTile("Down", 1);
                    break;
                
                case ConsoleKey.LeftArrow when board.ZeroPosX > 0:
                    board.MoveTile("Left", 1);
                    break;
                
                case ConsoleKey.UpArrow when board.ZeroPosY > 0:
                    board.MoveTile("Up", 1);
                    break;
                
                //New Game
                case ConsoleKey.N:
                    NewGame();
                    board.Shuffle();
                    Display.ShowBoard(board.Board, board.WinBoard);
                    break;
                
                //debugging win condition
                case ConsoleKey.W:
                    board.DefaultPosition();
                    Console.Clear();
                    Display.ShowBoard(board.Board, board.WinBoard);
                    break;
                
                //for debug cases
                /*case ConsoleKey.D:
                    Console.Clear();
                    break;*/
                    
    

            }
            
            
            Display.ShowBoard(board.Board, board.WinBoard);
            
            
            if (board.СheckWin())
            {
                Display.ShowWin();
                Console.WriteLine("Press enter to start new game");
                Console.ReadLine();
                NewGame();
                board.Shuffle();
                Display.ShowBoard(board.Board, board.WinBoard);
            }
        }
        while (e.Key != ConsoleKey.Escape);
    }
}