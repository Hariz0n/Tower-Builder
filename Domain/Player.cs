namespace TowerBuilder.Domain
{
    public class Player
    {
        public Player(string name, Field field)
        {
            Name = name;
            Field = field;
        }
        
        public string Name { get; set; }
        public Field Field { get; set; }

        public double Score { get; set; } = 0;

        public override string ToString()
        {
            return "Player: " + Name;
        }

        public int GetScore()
        {
            var totalFieldsCount = Field.Size * (Field.Size - 1);
            var placedBlocksCount = Field.GetBlocks().Count;
            return (totalFieldsCount - placedBlocksCount) * 100 + 100;
        }
    }
}