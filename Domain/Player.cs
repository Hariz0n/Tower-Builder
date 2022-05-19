namespace TowerBuilder.Domain
{
    public class Player : IPlayer
    {
        public Player(string name, Field field)
        {
            Name = name;
            Field = field;
        }
        
        public string Name { get; set; }
        public Field Field { get; set; }
    }
}