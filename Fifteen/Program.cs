using Fifteen.Core;

namespace Fifteen
{
    internal static class Program
    {
        static void Main()
        {
            var game = new GameModel(4);
            Application.Run(new Form1(game) { ClientSize = new Size(300, 300) });
        }
    }
}