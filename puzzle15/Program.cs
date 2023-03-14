// puzzle15 version 0.39

namespace Puzzle15;



internal class Program
{
    public static void Main(string[] args)

    { 
        GameBoard board = new GameBoard();
        Output showGameBoard = new Output();

        void NewGame()
        {
            board.DefaultPosition();
            showGameBoard.FillCanvas();
            showGameBoard.FillColorCanvas();
            ShowGame();
        }

        void ShowGame()
        {
            Console.Clear();
            showGameBoard.InitBoard(board.Board);
            showGameBoard.ShowAll();
        }

        NewGame();
        board.Shuffle();
        ShowGame();
        
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
                    ShowGame();
                    break;
                
                //debugging win condition
                case ConsoleKey.W:
                    board.DefaultPosition();
                    ShowGame();
                    break;
                
                //for debug cases
                case ConsoleKey.D:
                    Console.Clear();
                    showGameBoard.FillCanvas();
                    showGameBoard.InitBoard(board.Board);
                    showGameBoard.ShowAll();
                    Console.ReadLine();
                    break;
            }
            
            ShowGame();
            
            if (board.СheckWin())
            {
                showGameBoard.DrawMessage(4,0, "Red", Dictionary.WinText);
                Console.Clear();
                showGameBoard.ShowAll();
                Console.ReadLine();
                NewGame();
                board.Shuffle();
                ShowGame();
            }
        }
        while (e.Key != ConsoleKey.Escape);
    }
}