namespace Actors.Player.Signals
{
    public class PlayerLevelIncreaseSignal
    {
        public PlayerLevelIncreaseSignal(PlayerModel model)
        {
            Model = model;
        }

        public PlayerModel Model { get; }
    }
}