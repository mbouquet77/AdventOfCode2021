namespace AOC2021Day4
{
    public class Bingo
    {
        public Bingo(List<string> input)
        {
            Input = input;
        }
        public List<string> Input { get; }

        public List<int> GetDrawList()
        {
            var line = Input[0];
            return line.Split(',').Select(int.Parse).ToList();
        }

        public List<Cell[,]> GetBoardList()
        {
            var result = new List<Cell[,]>();

            var lineNb = 2;

            while (lineNb < Input.Count - 1)
            {
                var board = new Cell[5, 5];
                var i = 0;

                for (var k = lineNb; k < lineNb + 5; k++)
                {
                    var boardLine = Input[k].Split(' ').Where(c => c != "").Select(int.Parse).ToArray();
                    var j = 0;
                    foreach (var line in boardLine)
                    {
                        board[i, j] = new Cell(line, false);
                        j++;
                    }
                    i++;
                }
                lineNb += i + 1;
                result.Add(board);
            }

            return result;
        }
        public List<Cell[,]> ModifyBoardList(List<Cell[,]> boardList, int draw)
        {
            foreach (var board in boardList)
            {
                foreach (var cell in board)
                {
                    if (cell.Number == draw)
                        cell.IsMarked = true;
                }
            }

            return boardList;
        }

        public bool HasAtLeastOneLine(Cell[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                var result = board[i, 0].IsMarked;

                for (var j=1; j< board.GetLength(1); j++)
                {
                    result = result && board[i, j].IsMarked;
                }

                if (result)
                {
                    return result;
                }
            }
            return false;
        }

        public bool HasAtLeastOneColumn(Cell[,] board)
        {
            for (var j = 0; j < board.GetLength(1); j++)
            {
                var result = board[0, j].IsMarked;

                for (var i = 1; i < board.GetLength(0); i++)
                {
                    result = result && board[i, j].IsMarked;
                }

                if (result)
                {
                    return result;
                }
            }
            return false;
        }
        public bool HasAtLeastOneDiagonal(Cell[,] board)
        {
            var result = board[0, 0].IsMarked;
            var length = board.GetLength(0);
            for (var i=1; i < length; i++)
            {
                result = result && board[i, i].IsMarked;
            }
            if (result)
                return true;

            result = board[length-1, length-1].IsMarked;
            for (var i = length-2; i >= 0; i--)
            {
                result = result && board[i, i].IsMarked;
            }
            if (result)
                return true;

            return false;
        }

        public int GetWinningResult()
        {
            var drawList = GetDrawList();
            var boardList = GetBoardList();

            foreach (var draw in drawList)
            {
                boardList = ModifyBoardList(boardList, draw);
                foreach (var board in boardList)
                {
                    if (HasAtLeastOneColumn(board) || HasAtLeastOneLine(board) || HasAtLeastOneDiagonal(board))
                    {
                        return draw * GetUnMarkedCellsSum(board);
                    }
                }
            }
            return 0;
        }

        public int GetLastWinningResult()
        {
            var drawList = GetDrawList();
            var boardList = GetBoardList();


            foreach (var draw in drawList)
            {
                boardList = ModifyBoardList(boardList, draw);
                var i = 0;
                while (i < boardList.Count)
                {
                    var board = boardList[i];
                    if (HasAtLeastOneColumn(board) || HasAtLeastOneLine(board) || HasAtLeastOneDiagonal(board))
                    {
                        if (boardList.Count == 1)
                            return draw* GetUnMarkedCellsSum(board);
                        else
                            boardList.Remove(board);
                    }
                    else
                        i++;
                }
            }

            return 0;

        }
        private int GetUnMarkedCellsSum(Cell[,] board)
        {
            var result = 0;
            foreach (var cell in board)
            {
                if (!cell.IsMarked)
                    result += cell.Number;
            }
            return result;
        }
    }


    public class Cell
    {
        public Cell(int number, bool isMarked)
        {
            Number = number;
            IsMarked = isMarked;
        }

        public int Number { get; }
        public bool IsMarked { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Cell cell &&
                   Number == cell.Number &&
                   IsMarked == cell.IsMarked;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number, IsMarked);
        }
    }
}
