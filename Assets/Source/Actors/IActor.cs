namespace Actors
{
    public interface IActor
    {
        public float MoveSpeed { get; }
        public float Health { get; set; }
        public float MaxHealth { get; }
    }
}