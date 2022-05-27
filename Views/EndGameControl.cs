using System;
using System.Drawing;
using System.Windows.Forms;
using TowerBuilder.Domain;

namespace TowerBuilder.Views
{
    public partial class EndGameControl : UserControl
    {
        private Game _game;
        private readonly Label _score;
        private readonly Label _heading;
        public EndGameControl()
        {
            BackColor = Color.DimGray;
            var table = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
            };

            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Padding = new Padding(20);
            _heading = new Label()
            {
                Size = new Size(270, 40),
                Text = "Ваш результат:",
                Font = new Font("Arial", 16),
                ForeColor = Color.White
            };

            _score = new Label()
            {
                Size = new Size(270, 40),
                Font = new Font("Arial", 14),
                Text = "",
                ForeColor = Color.White
            };

            var homeButton = new Button()
            {
                Size = new Size(200 , 40),
                Text = "В главное меню",
                Font = new Font("Arial", 14),
                ForeColor = Color.Yellow,
                BackColor = Color.Black,
            };
            
            homeButton.Click += HomeButtonOnClick;
            table.Controls.Add(_heading, 0, 0);
            table.Controls.Add(_score, 0 , 2);
            table.Controls.Add(homeButton, 0 , 4);
            Controls.Add(table);
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;
            _game = game;
        }

        public void UpdateText()
        {
            _score.Text = $@"{_game.Player.GetScore()} очков";
            _heading.Text = $@"{_game.Player.Name}, ваш результат:";
        }
        
        private void HomeButtonOnClick(object sender, EventArgs e)
        {
            _game.ChangeStage(Stages.NotStarted);
        }
    }
}