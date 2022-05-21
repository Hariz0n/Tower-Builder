using System;

namespace TowerBuilder.Domain
{
    public class Game
    {
        private Difficulty Difficulty { get; }
        private Player _player1;
        private Stages _stages = Stages.NotStarted;

        public event Action<Stages> StageChanged; 
        public Game(Difficulty dif)
        {
            Difficulty = dif;
            _player1 = new Player("Player 1", new Field(5));
        }

        public void Start(string name)
        {
            _player1 = new Player(name, new Field(7));
            ChangeStage(Stages.Started);
        }

        void ChangeStage(Stages stage)
        {
            _stages = stage;
            StageChanged?.Invoke(stage);
        }
    }
}