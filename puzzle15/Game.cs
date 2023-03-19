namespace Puzzle15;

public class Game
{
    Texts texts = new Texts();
    GameBoard board = new GameBoard();
    Graphics buffer = new Graphics();
    ScoreBoard players = new ScoreBoard();
    Player player = new Player();
    string name = "i7aKeT";
    
    void NewGame()
    {
        player = new Player(name);
        board.DefaultPosition();
        board.Shuffle();
        buffer.FillCanvas();
        buffer.FillColorCanvas();
        buffer.InitBoard(board.Board, board.WinBoard, texts.Numbers);
        buffer.DrawMessage(8,68, "Green", texts.HowToPlay);
        buffer.DrawMessage(1,68, "Green", texts.NameMovesTimes);
        buffer.DrawMessage(3,77, "Green", player.Moves.ToString());
        buffer.DrawMessage(1,77, "Green", player.Name);
        buffer.DrawMessage(5,77, "Green", player.TimeSpent());
        buffer.DrawBoxUsingSymbol(15, 68, "Green", 13, 29, ' ');
        buffer.DrawMessage(15,69, "Green", texts.ScoreLabel);
        buffer.DrawMessage(16,69, 16, 22, "Green", players.List);
        Console.Clear();
        buffer.Show();
    }
    
    public void Play()
    {
        ConsoleKeyInfo e;
        do
        {
            e = Console.ReadKey();
            switch (e.Key)
            {
                case ConsoleKey.RightArrow when board.ZeroPosX < 3:
                    board.MoveTile("Right", 1);
                    player.AddMoves();
                    break;

                case ConsoleKey.DownArrow when board.ZeroPosY < 3:
                    board.MoveTile("Down", 1);
                    player.AddMoves();
                    break;

                case ConsoleKey.LeftArrow when board.ZeroPosX > 0:
                    board.MoveTile("Left", 1);
                    player.AddMoves();
                    break;

                case ConsoleKey.UpArrow when board.ZeroPosY > 0:
                    board.MoveTile("Up", 1);
                    player.AddMoves();
                    break;

                //New Game
                case ConsoleKey.N:
                    NewGame();
                    break;

                case ConsoleKey.C:
                    Console.WriteLine("Type your Name");
                    name = Console.ReadLine();
                    player.ChangeName(name);
                    buffer.DrawMessage(1, 77, "Green", texts.EmptyNameField);
                    buffer.DrawMessage(1, 77, "Green", player.Name);
                    break;

                //debugging win condition
                case ConsoleKey.W:
                    board.DefaultPosition();
                    break;

                //for debug cases
                case ConsoleKey.D:
                    //Console.ReadLine();
                    break;
            }

            buffer.DrawMessage(3, 77, "Green", player.Moves.ToString());
            buffer.DrawMessage(5, 77, "Green", player.TimeSpent());
            buffer.InitBoard(board.Board, board.WinBoard, texts.Numbers);
            Console.Clear();
            buffer.Show();
            CheckWin();
        } while (e.Key != ConsoleKey.Escape);
    }
    
    public void CheckWin()
    {
        if (board.СheckWin())
        {
            buffer.DrawMessage(4, 15, "Red", texts.Win);
            player.TimeSpent();
            players.List.Add(player);
            players.Sort();
            players.SaveList();
            Console.Clear();
            buffer.Show();
            Console.ReadLine();
            NewGame();
        }
    }
    
    public void Begin ()
    {
        ScoreBoard.NewSFile();
        players.LoadList();
        NewGame();
        Play();
    }
}