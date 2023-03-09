using Fifteen.Core;
using System.Data.Common;

namespace Fifteen
{
    public partial class Form1 : Form
    {
        GameModel gameModel;

        public Form1(GameModel game)
        {
            this.gameModel = game;
            game.GenerateField();

            var table = new TableLayoutPanel();
            for (int i = 0; i < game.Size; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / game.Size));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / game.Size));
            }
            for (int row = 0; row < game.Size;row++)
            {
                for (int column = 0; column < game.Size;column++)
                {
                    var iRow = row;
                    var iColumn = column;
                    var button = new Button() { Dock = DockStyle.Fill,
                                                Text = gameModel.Field[row, column].Value.ToString(),
                    };
                    table.Controls.Add(button, iColumn, iRow);
                }
            }
            table.Dock = DockStyle.Fill;
            Controls.Add(table);
        }
    }
}