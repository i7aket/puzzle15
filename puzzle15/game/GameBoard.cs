namespace puzzle15;

public class GameBoard
    { 
        public GameStatus GameStatus { get; private set; }
        private int _zeroPosLeft = GamePuzzle15.Columns-1;
        private int _zeroPosTop = GamePuzzle15.Rows-1;
        private const int Shuffles = (GamePuzzle15.Columns+1)*(GamePuzzle15.Rows+1); // How many times to shuffle board
        private int Rows;
        private int Columns;
        
        private int[,] _board;
        private readonly int[,] _winBoard;
        
        public event Action<NumbersIndexBox> InitBoard;
        public event Action ResetMoves;
        public event Action AddMoves;



        public int [,] winBoard()
        {
            int counter = 1;
            int[,] arr = new int[GamePuzzle15.Rows, GamePuzzle15.Columns];
            for (int i = 0; i < GamePuzzle15.Rows; i++)
            {
                for (int j = 0; j < GamePuzzle15.Columns; j++)
                {
                    arr[i, j] = counter++;
                }
            }
            arr[arr.GetUpperBound(0), arr.GetUpperBound(1)] = 0;
            return arr;
        }

        public GameBoard()
        {
            if (GamePuzzle15.Rows < 3 || GamePuzzle15.Columns < 3 || GamePuzzle15.Rows > 9 || GamePuzzle15.Columns > 9)
            {
                throw new ArgumentException("Rows or Columns cant be less then 3 or more then 9");
            }
            Rows = GamePuzzle15.Rows;
            Columns = GamePuzzle15.Columns;
            _board = winBoard();
            _winBoard = winBoard();
        }

        private void Shuffle()
        {
            Random random = new Random();
            
            for (int i = 0; i < Shuffles; i++)
            {
                int rndLeft = random.Next(1, GamePuzzle15.Columns);
                int rndTop = random.Next(1, GamePuzzle15.Rows);
                
                Up(rndTop); 
                
                Left(rndLeft);
                
                Down(rndTop);
                
                Right(rndLeft);
                
            }
            ResetMoves();
        }

        public void DefaultPosition()
        {
            _zeroPosLeft = GamePuzzle15.Columns-1;
            _zeroPosTop = GamePuzzle15.Rows-1;
            _board = winBoard();
        }

        public void Right(int repeat = 1)
        {
            if (_zeroPosLeft <= GamePuzzle15.Columns)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch
                    _board[_zeroPosTop, _zeroPosLeft] = _board[_zeroPosTop, _zeroPosLeft + 1];
                    _board[_zeroPosTop, _zeroPosLeft + 1] = 0;
                    _zeroPosLeft++;
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
            if (_zeroPosTop <= GamePuzzle15.Rows)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch
                    _board[_zeroPosTop, _zeroPosLeft] = _board[_zeroPosTop + 1, _zeroPosLeft];
                    _board[_zeroPosTop + 1, _zeroPosLeft] = 0;
                    _zeroPosTop++;
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
            if (_zeroPosLeft > 0)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch   
                    _board[_zeroPosTop, _zeroPosLeft] = _board[_zeroPosTop, _zeroPosLeft - 1];
                    _board[_zeroPosTop, _zeroPosLeft - 1] = 0;
                    _zeroPosLeft--;
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
            if (_zeroPosTop > 0)
            {
                for (int i = 0; i < repeat; i++)
                {
                    int index1 = Array.IndexOf(_board.Cast<int>().ToArray(), 0); //Saving Index of Zero before switch
                    _board[_zeroPosTop, _zeroPosLeft] = _board[_zeroPosTop - 1, _zeroPosLeft];
                    _board[_zeroPosTop - 1, _zeroPosLeft] = 0;
                    _zeroPosTop--;
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
