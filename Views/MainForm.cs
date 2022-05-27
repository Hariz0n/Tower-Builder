using System.Drawing;
using System.Windows.Forms;
using TowerBuilder.Domain;

namespace TowerBuilder.Views
{
    public partial class MainForm : Form
    {
        private Game _game;
        private readonly StartControl _startControl;
        private readonly FieldControl _fieldControl;
        private readonly InstructingControl _instructingControl;
        private readonly EndGameControl _endGameControl;
        public MainForm()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Size = new Size(1280, 720);
            _game = new Game(Difficulty.Easy);
            _game.StageChanged += GameOnStageChanged;
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            _startControl = new StartControl()
            {
                Location = new Point(Size.Width / 3, Size.Height / 6),
                Size = new Size(ClientSize.Width / 4, ClientSize.Height * 4 / 6)
            };

            _instructingControl = new InstructingControl()
            {
                Location = new Point(Size.Width / 3, Size.Height / 6),
                Size = new Size(ClientSize.Width / 4, ClientSize.Height * 4 / 6)
            };

            _fieldControl = new FieldControl()
            {
                Size = new Size(450, 450),
                Location = new Point(ClientSize.Width * 2/ 6, ClientSize.Height * 2/ 7)
            };

            _endGameControl = new EndGameControl()
            {
                Location = new Point(Size.Width / 3, Size.Height / 6),
                Size = new Size(ClientSize.Width / 4, ClientSize.Height * 4 / 6)
            };
            
            Controls.Add(_startControl);
            Controls.Add(_fieldControl);
            Controls.Add(_endGameControl);
            Controls.Add(_instructingControl);
            ShowStartScreen();
        }

        private void GameOnStageChanged(Stages stage)
        {
            switch (stage)
            {
                case Stages.NotStarted:
                    ShowStartScreen();
                    break;
                case Stages.Instruction:
                    ShowInstructionScreen();
                    break;
                case Stages.Started:
                    ShowGameScreen();
                    break;
                case Stages.Finished:
                    ShowEndScreen();
                    break;
            }
        }
        private void ShowStartScreen()
        {
            HideScreens();
            _startControl.Configure(_game);
            _startControl.Show();
        }
        
        private void ShowInstructionScreen()
        {
            HideScreens();
            _instructingControl.Configure(_game);
            _instructingControl.Show();
        }
        
        private void ShowGameScreen()
        {
            HideScreens();
            _fieldControl.Configure(_game);
            _fieldControl.Show();
        }

        private void ShowEndScreen()
        {
            HideScreens();
            _endGameControl.Configure(_game);
            _endGameControl.UpdateScore();
            _endGameControl.Show();
        }
        
        private void HideScreens()
        {
            _startControl.Hide();
            _instructingControl.Hide();
            _fieldControl.Hide();
            _endGameControl.Hide();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startControl1 = new TowerBuilder.Views.StartControl();
            this.endGameControl1 = new TowerBuilder.Views.EndGameControl();
            this.SuspendLayout();
            // 
            // startControl1
            // 
            this.startControl1.BackColor = System.Drawing.Color.DimGray;
            this.startControl1.Location = new System.Drawing.Point(97, 94);
            this.startControl1.Name = "startControl1";
            this.startControl1.Padding = new System.Windows.Forms.Padding(20);
            this.startControl1.Size = new System.Drawing.Size(311, 441);
            this.startControl1.TabIndex = 0;
            // 
            // endGameControl1
            // 
            this.endGameControl1.Location = new System.Drawing.Point(553, 288);
            this.endGameControl1.Name = "endGameControl1";
            this.endGameControl1.Size = new System.Drawing.Size(299, 208);
            this.endGameControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1247, 827);
            this.Controls.Add(this.endGameControl1);
            this.Controls.Add(this.startControl1);
            this.Name = "MainForm";
            this.ResumeLayout(false);
        }

        private TowerBuilder.Views.StartControl startControl1;
        private TowerBuilder.Views.EndGameControl endGameControl1;
    }
}