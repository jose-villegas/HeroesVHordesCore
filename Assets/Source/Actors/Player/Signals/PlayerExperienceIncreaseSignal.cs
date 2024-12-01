namespace Actors.Player.Signals
{
    public class PlayerExperienceIncreaseSignal
    {
        public PlayerExperienceIncreaseSignal(int previousExperience, PlayerModel model)
        {
            PreviousExperience = previousExperience;
            Model = model;
        }

        public int PreviousExperience { get; }

        public PlayerModel Model { get; }
    }
}