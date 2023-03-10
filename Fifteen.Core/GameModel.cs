namespace Fifteen.Core
{
    public class GameModel
    {
        public Cell[,] Field { get; set; }
        public int Size { get; set; }

        public GameModel(int size)
        {
            Size = size;
            Field = new Cell[Size, Size];
        }
        public void GenerateField()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Field[i, j] = new Cell(i * 4 + j + 1);
                }
            }
            Field[Size - 1, Size - 1].MakeEmpty();
        }

        public Cell this[int row, int column]
        {
            get 
            {   
                return Field[row, column]; 
            }
            set => Field[row, column] = value;
        }
        
        public HashSet<(int row, int column)> GetNeighbours(int row, int column)
        {
            int[] d = { -1,0,  1 };
            var result = d
                .SelectMany(x => d
                    .Where(y => (x==0 || y == 0) && !(x == 0 && y == 0)) 
                    .Where(y => x + row < Size && x + row >= 0 && y + column < Size && y + column >= 0)
                    .Select(y => (row + x, column + y)))
                .ToHashSet();
            return result;
        }


        void SetState(int row, int column, int val)
        {
            Field[row, column].Val = val;
            Field[row, column].IsEmpty = val == 0;
            if (StateChanged != null) StateChanged(row, column);
        }

        public void MoveEmptyCell(int row, int column)
        {
            if (!Field[row, column].IsEmpty)
            {
                // Добавть проверку на наличие пустых соседей
                try
                {
                    var neighbour = GetNeighbours(row, column).Where(x => Field[x.row, x.column].IsEmpty).First();
                    SetState(neighbour.row, neighbour.column, Field[row, column].Val);
                    SetState(row, column, 0);
                }
                catch { }
            }
        }

        public event Action<int, int> StateChanged;
    }
}