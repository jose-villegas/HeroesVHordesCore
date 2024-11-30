namespace Actors
{
    public interface IActor
    {
        public float MoveSpeed { get; }
        public float Health { get; }
        public float MaxHealth { get; }
    }
}