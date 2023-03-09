using Fifteen.Core;

namespace FifteenTest
{
    public class GameModelTest
    {
        [Fact(DisplayName ="Создание")]
        public void Test1()
        {
            var model = new GameModel(4);
            model.GenerateField();
            Assert.True(model.Field[model.Size - 1, model.Size - 1].IsEmpty);
        }

        [Fact(DisplayName = "Доступ к соседям")]
        public void Test2()
        {
            var model = new GameModel(4);
            model.GenerateField();
            var neighbours = model.GetNeighbours(1, 1);
            Assert.Equal(8, neighbours.Count());

            neighbours = model.GetNeighbours(0, 0);
            Assert.Equal(3, neighbours.Count());

            neighbours = model.GetNeighbours(4, 5);
            Assert.Equal(0, neighbours.Count());
        }
    }
}