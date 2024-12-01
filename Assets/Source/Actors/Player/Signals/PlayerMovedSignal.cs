using UnityEngine;

namespace Actors.Player.Signals
{
    public class PlayerMovedSignal
    {
        public PlayerMovedSignal(Vector3 position)
        {
            Position = position;
        }

        public Vector3 Position { get; }
    }
}