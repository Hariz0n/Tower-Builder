namespace TowerBuilder.Domain
{
    public class Game
    {
        private Difficulty Difficulty { get; set; }
        private Player Player1;
        public Game(string name, Difficulty dif)
        {
            Difficulty = dif;
            Player1 = new Player(name, new Field(5));
        }
    }
}