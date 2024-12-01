namespace Actors.Enemy.Signals
{
    public class EnemyKillSignal
    {
        public EnemyKillSignal(EnemyModel model)
        {
            Model = model;
        }

        public EnemyModel Model { get; }
    }
}