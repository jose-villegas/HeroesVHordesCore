namespace Player
{
    public interface IPlayer
    {
        public float MoveSpeed { get; }
        public float Health { get; }
        public float MaxHealth { get; }
        public float Level { get; }
    }
}