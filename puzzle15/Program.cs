// puzzle15 version 0.2

namespace puzzle15;



internal class Program
{
    public static void Main(string[] args)

    { 
        GameBoard board = new GameBoard();
        /*Display canvas = new Display();
        canvas.Fillcanvas();*/
        
        

        
        void NewGame()
        {
            board.Defaultposition(); 
            Display.ShowBoard(board.Board, board.Winboard);
        
        }
        
        Display.ShowBoard(board.Board, board.Winboard);
        NewGame();
        board.Shuffle();
        Display.ShowBoard(board.Board, board.Winboard);
        
        ConsoleKeyInfo e;
        do
        {
            e = Console.ReadKey();

            switch (e.Key)
            {
                case ConsoleKey.RightArrow when board.ZeroPosX < 3:
                    board.Movetile("Right", 1);    
                    break;
                
                case ConsoleKey.DownArrow when board.ZeroPosY < 3:
                    board.Movetile("Down", 1);
                    break;
                
                case ConsoleKey.LeftArrow when board.ZeroPosX > 0:
                    board.Movetile("Left", 1);
                    break;
                
                case ConsoleKey.UpArrow when board.ZeroPosY > 0:
                    board.Movetile("Up", 1);
                    break;
                
                //New Game
                case ConsoleKey.N:
                    NewGame();
                    board.Shuffle();
                    Display.ShowBoard(board.Board, board.Winboard);
                    break;
                
                //debugging win condition
                case ConsoleKey.W:
                    board.Defaultposition();
                    Console.Clear();
                    Display.ShowBoard(board.Board, board.Winboard);
                    break;
            }
            
            
            Display.ShowBoard(board.Board, board.Winboard);
            
            
            if (board.Chekwin())
            {
                Display.Showwin();
                Console.WriteLine("Press enter to start new game");
                Console.ReadLine();
                NewGame();
                board.Shuffle();
                Display.ShowBoard(board.Board, board.Winboard);
            }
        }
        while (e.Key != ConsoleKey.Escape);
    }
}