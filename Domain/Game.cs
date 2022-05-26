using System;

namespace TowerBuilder.Domain
{
    public class Game
    {
        private Difficulty Difficulty { get; }
        public Player Player1;
        private Stages _stages = Stages.NotStarted;

        public event Action<Stages> StageChanged; 
        public Game(Difficulty dif)
        {
            Difficulty = dif;
        }

        public void Start(string name, Difficulty difficulty)
        {
            Player1 = new Player(name, new Field(7, difficulty));
            ChangeStage(Stages.Started);
        }

        public void EndGame()
        {
            ChangeStage(Stages.Finished);
        }

        public void ChangeStage(Stages stage)
        {
            _stages = stage;
            StageChanged?.Invoke(stage);
        }
    }
}