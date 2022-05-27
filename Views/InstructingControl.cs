using System;
using System.Drawing;
using System.Windows.Forms;
using TowerBuilder.Domain;
using TowerBuilder.Properties;

namespace TowerBuilder.Views
{
    public partial class InstructingControl : UserControl
    {
        private Game _game;
        public InstructingControl()
        {
            BackColor = Color.DimGray;
            Padding = new Padding(20);
            var table = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
            };

            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var label = new Label()
            {
                Text = Resources.InstructionLabel,
                Font = new Font("Arial",  16),
                Location = new Point(Padding.All, Padding.All),
                Size = new Size(Width, 25),
                ForeColor = Color.White
            };
            var instructionText = new Label()
            {
                MaximumSize = new Size(300, 300),
                Location = new Point(Padding.All, label.Bottom + 20),
                Text = Resources.Instruction,
                Font = new Font("Arial", 14),
                AutoSize = true,
                ForeColor = Color.White
            };
            var button = new Button()
            {
                Size = new Size(200 , 40),
                Text = Resources.Start_a_game,
                Font = new Font("Arial", 14),
                ForeColor = Color.Yellow,
                BackColor = Color.Black,
            };
            
            button.Click += ButtonOnClick;
            table.Controls.Add(label, 0, 0);
            table.Controls.Add(instructionText, 0, 2);
            table.Controls.Add(button, 0 ,4);
            Controls.Add(table);
        }

        public void Configure(Game game)
        {
            if(_game != null)
                return;
            _game = game;
        }
        
        private void ButtonOnClick(object sender, EventArgs e)
        {
            _game.ChangeStage(Stages.Started);
            _game.IsInstructed = true;
        }
    }
}