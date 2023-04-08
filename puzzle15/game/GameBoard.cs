namespace puzzle15;

public class GameBoard
    { 
        public GameStatus GameStatus { get; private set; }
        private int _zeroPosX = 3;
        private int _zeroPosY = 3;
        private const int Shuffles = 20; // How many times to shuffle board
        
        private int[,] _board;
        
        public event Action<NumbersIndexBox> InitBoard;
        public event Action ResetMoves;
        public event Action AddMoves;

        private readonly int[,] _winBoard =
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 0 },
        };


        public GameBoard()
        {
            _board = new[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 },
            };
        }

        private void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Shuffles; i++)
            {
                int rnd = random.Next(1, Const.RowSize + 1);
                Up(rnd);
                Thread.Sleep(25);
                Left(rnd);
                Thread.Sleep(25);
                Down(rnd);
                Thread.Sleep(25);
                Right(rnd);
                Thread.Sleep(25);
            }
            ResetMoves();
        }

        public void DefaultPosition()
        {
            _zeroPosX = 3;
            _zeroPosY = 3;
            _board = new[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 },
            };
        }

        public void Right(int repeat = 1)
        {
            if (_zeroPosX < Const.RowSize)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch
                    _board[_zeroPosY, _zeroPosX] = _board[_zeroPosY, _zeroPosX + 1];
                    _board[_zeroPosY, _zeroPosX + 1] = 0;
                    _zeroPosX++;
                    AddMoves();
                    int index2 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero after switch
                    IEnumerable<int> index = new int[] { index1, index2 };
                    IEnumerable<int> indexAll = _board.Cast<int>();
                    InitBoard(new NumbersIndexBox(indexAll, index));
                    CheckWin();
                }
            }
        }

        public void Down(int repeat = 1)
        {
            if (_zeroPosY < Const.RowSize)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch
                    _board[_zeroPosY, _zeroPosX] = _board[_zeroPosY + 1, _zeroPosX];
                    _board[_zeroPosY + 1, _zeroPosX] = 0;
                    _zeroPosY++;
                    AddMoves();
                    int index2 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero after switch
                    IEnumerable<int> index = new int[] { index1, index2 };
                    IEnumerable<int> indexAll = _board.Cast<int>();
                    InitBoard(new NumbersIndexBox(indexAll, index));
                    CheckWin();
                }
            }
        }

        public void Left(int repeat = 1)
        {
            if (_zeroPosX > 0)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch   
                    _board[_zeroPosY, _zeroPosX] = _board[_zeroPosY, _zeroPosX - 1];
                    _board[_zeroPosY, _zeroPosX - 1] = 0;
                    _zeroPosX--;
                    AddMoves();
                    int index2 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero after switch
                    IEnumerable<int> index = new int[] { index1, index2 };
                    IEnumerable<int> indexAll = _board.Cast<int>();
                    InitBoard(new NumbersIndexBox(indexAll, index));
                    CheckWin();
                }
            }
        }

        public void Up(int repeat = 1)
        {
            if (_zeroPosY > 0)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch
                    _board[_zeroPosY, _zeroPosX] = _board[_zeroPosY - 1, _zeroPosX];
                    _board[_zeroPosY - 1, _zeroPosX] = 0;
                    _zeroPosY--;
                    AddMoves();
                    int index2 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero after switch
                    IEnumerable<int> index = new int[] { index1, index2 };
                    IEnumerable<int> indexAll = _board.Cast<int>();
                    InitBoard(new NumbersIndexBox(indexAll, index));
                    CheckWin();
                }
            }
        }
        
        private void CheckWin()
        {
            if (_board.Cast<int>()
                      .SequenceEqual(_winBoard
                      .Cast<int>()))
            {
                GameStatus = GameStatus.Win;
            }
        }

        public void NewGame()
        {
            GameStatus = GameStatus.InProgress;
            Shuffle();
        }

        public void EngGame()
        {
            GameStatus = GameStatus.Win;
        }
    }
