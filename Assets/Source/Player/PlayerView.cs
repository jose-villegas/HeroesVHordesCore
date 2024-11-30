using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public void Move(Vector3 position)
        {
            transform.position = position;
        }
    }
}