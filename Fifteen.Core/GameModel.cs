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
        
        public HashSet<Cell> GetNeighbours(int row, int column)
        {
            int[] d = { -1, 0, 1 };
            var result = d
                .SelectMany(x => d
                    .Where(y => x != 0 || y != 0)
                    .Where(y => x + row < Size && x + row >= 0 && y + column < Size && y + column >= 0)
                    .Select(y => Field[row + x, column + y]))
                .ToHashSet();
            return result;
        }
    }
}