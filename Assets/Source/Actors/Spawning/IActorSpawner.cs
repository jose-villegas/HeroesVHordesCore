namespace Actors.Spawning
{
    public interface IActorSpawner
    {
        public float Frequency { get; }
        public int SpawnPerCycle { get; }
        public float Delay { get; }
        public float Lifetime { get; }
    }
}