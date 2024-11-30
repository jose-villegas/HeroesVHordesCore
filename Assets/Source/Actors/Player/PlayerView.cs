using UnityEngine;

namespace Actors.Player
{
    public class PlayerView : MonoBehaviour
    {
        public void Move(Vector3 movement)
        {
            transform.position += movement;
        }
    }
}