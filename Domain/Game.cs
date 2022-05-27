using System;

namespace TowerBuilder.Domain
{
    public class Game
    {
        private Difficulty Difficulty { get; }
        public bool IsInstructed { get; set; }
        public bool IsPaused { get; set; }
        public Player Player;
        public Stages Stage = Stages.NotStarted;
        public event Action<Stages> StageChanged; 
        public Game(Difficulty dif)
        {
            Difficulty = dif;
        }

        public void Start()
        {
            if (Stage == Stages.Started && Stage != Stages.Finished)
                return;
            ChangeStage(Stages.Started);
        }

        public void InitializePlayer(string name)
        {
            Player = new Player(name, new Field(7, Difficulty));
        }

        public void Introduce()
        {
            if (Stage != Stages.NotStarted)
                return;
            ChangeStage(Stages.Instruction);
        }

        public void EndGame()
        {
            if (Stage != Stages.Started)
                return;
            
            ChangeStage(Stages.Finished);
        }

        public void ChangeStage(Stages stage)
        {
            Stage = stage;
            StageChanged?.Invoke(stage);
        }
    }
}