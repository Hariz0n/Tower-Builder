using System.Drawing;
using System.Windows.Forms;
using TowerBuilder.Domain;

namespace TowerBuilder.Views
{
    public partial class MainForm : Form
    {
        private Game _game;
        private StartControl StartControl;
        private FieldControl FieldControl;
        public MainForm()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Size = new Size(1280, 720);
            _game = new Game(Difficulty.Easy);
            _game.StageChanged += GameOnStageChanged;
            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            StartControl = new StartControl()
            {
                Location = new Point(Size.Width / 3, Size.Height / 6),
                Size = new Size(ClientSize.Width / 4, ClientSize.Height * 4 / 6)
            };

            FieldControl = new FieldControl()
            {
                Size = new Size(450, 450),
                Location = new Point(ClientSize.Width * 2/ 6, ClientSize.Height * 2/ 7)
            };
            
            Controls.Add(StartControl);
            Controls.Add(FieldControl);
            ShowStartScreen();
        }

        private void GameOnStageChanged(Stages stage)
        {
            switch (stage)
            {
                case Stages.NotStarted:
                    ShowStartScreen();
                    break;
                case Stages.Started:
                    ShowGameScreen();
                    break;
            }
        }

        private void ShowStartScreen()
        {
            HideScreens();
            StartControl.Configure(_game);
            StartControl.Show();
        }

        private void ShowGameScreen()
        {
            HideScreens();
            FieldControl.Configure(_game);
            FieldControl.Show();
        }
        
        private void HideScreens()
        {
            StartControl.Hide();
            FieldControl.Hide();
        }
    }
}