using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TowerBuilder.Domain;

namespace TowerBuilder.Views
{
    public partial class FieldControl : UserControl
    {
        private Field _field;
        private Game _game;
        private Dictionary<Point, Rectangle> _pointToRect;
        private bool _configured;
        private readonly Timer _timer;
        public FieldControl()
        {
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Click += OnClick;
            _timer = new Timer();
            _timer.Interval = 351;
            _timer.Tick += TimerOnTick;
        }

        public void Configure(Game game)
        {
            if (_configured)
                return;
            this._game = game;
            _field = game.Player.Field;
            _field.BlockMoved += Invalidate;
            _field.LevelChanged += FieldOnLevelChanged;
            _field.GameEnded += FieldOnGameEnded;
            _pointToRect = GeneratePointToRectangle(_field, Width, Height);
            _configured = true;
            _timer.Start();
        }

        private void FieldOnLevelChanged()
        {
            _timer.Interval -= 50;
        }
        private void FieldOnGameEnded()
        {
            _timer.Stop();
            _configured = false;
            _game.Player.GetScore();
            _timer.Interval = 351;
            _game.ChangeStage(Stages.Finished);
        }
        
        private void OnClick(object sender, EventArgs e)
        {
            _timer.Stop();
            _field.PlaceBox();
            _timer.Start();
        }
        
        private void TimerOnTick(object sender, EventArgs e)
        {
            _field.MovePseudoBlockHorizontal();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.FillRectangle(Brushes.Transparent,  0,0,Width, Height,);
            if(!_configured)
                return;
            var brush = new TextureBrush(Properties.Resources.Crate);
            
            foreach (var pair in _pointToRect) 
                e.Graphics.DrawRectangle(Pens.Black, pair.Value);
            foreach (var point in _field.GetBlocks())
            {
                e.Graphics.FillRectangle(brush, _pointToRect[point]);
            }
        }
        
        private static Dictionary<Point, Rectangle> GeneratePointToRectangle(Field field, int width, int height)
        {
            var result = new Dictionary<Point, Rectangle>();
            for (var x = 0; x < field.Size; x++)
            {
                for (int y = 0; y < field.Size; y++)
                {
                    var left = (width - 2) * x / field.Size + 1;
                    var right = (width - 2) * (x + 1) / field.Size + 1;
                    var top = (height - 2) * y / field.Size + 1;
                    var bottom = (height - 2) * (y + 1) / field.Size + 1;
                    var rectangle = new Rectangle(left, top, right - left, bottom - top);
                    result.Add(new Point(x, y), rectangle);
                }
            }
            return result;
        }
    }
}