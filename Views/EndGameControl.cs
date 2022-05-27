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
        public EndGameControl()
        {
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
            var heading = new Label()
            {
                Size = new Size(270, 40),
                Text = "Ваш результат:",
                Font = new Font("Arial", 16)
            };

            _score = new Label()
            {
                Size = new Size(270, 40),
                Font = new Font("Arial", 14),
                Text = ""
            };

            var homeButton = new Button()
            {
                Size = new Size(200 , 40),
                Text = "В главное меню",
                Font = new Font("Arial", 14)
            };
            
            homeButton.Click += HomeButtonOnClick;
            table.Controls.Add(heading, 0, 0);
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

        public void UpdateScore()
        {
            _score.Text = $@"{_game.Player.GetScore()} очков";
        }
        
        private void HomeButtonOnClick(object sender, EventArgs e)
        {
            _game.ChangeStage(Stages.NotStarted);
        }
    }
}