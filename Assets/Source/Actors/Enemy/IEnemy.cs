namespace Actors.Enemy
{
    public interface IEnemy : IActor, IDamageHandler
    {
        public float InfluenceRadius { get; }
    }
}