using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TowerBuilder.Domain;

namespace TowerBuilder.Views
{
    public partial class StartControl : UserControl
    {
        private Game _game;
        private readonly TextBox _textBox;
        private TableLayoutPanel _tableLayoutPanel;
        private readonly Button button;

        public StartControl()
        {
            BackColor = Color.DimGray;
            Padding = new Padding(20);
            var pictureBox = new PictureBox()
            {
                Location = new Point(Padding.All, Padding.All),
                Image = Properties.Resources.Logo,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(270, 40),
            };
            var label = new Label()
            {
                Size = new Size(270, 25),
                Location = new Point(Padding.All + 30, pictureBox.Bottom + 15),
                Text = @"Введите имя игрока",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Yellow
            };

            _textBox = new TextBox()
            {
                Size = new Size(180, 30),
                Font = new Font("Arial", 10),
                Location = new Point(Padding.All + 45, label.Bottom + 15),
                Margin = new Padding(0,0,0,10)
            };

            button = new Button()
            {
                Size = new Size(180, 30),
                Font = new Font("Arial", 10),
                ForeColor = Color.Yellow,
                Location = new Point(Padding.All + 45, _textBox.Bottom + 15),
                BackColor = Color.Black,
                Text = @"Начать игру"
            };
            
            button.Click += ButtonOnClick;
            Controls.Add(pictureBox);
            Controls.Add(label);
            Controls.Add(_textBox);
            Controls.Add(button);
        }
        
        private void ButtonOnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_textBox.Text))
                _game.Start(_textBox.Text, Difficulty.Easy);
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;
            _game = game;
        }
    }
}