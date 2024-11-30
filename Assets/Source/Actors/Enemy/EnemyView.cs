using UnityEngine;

namespace Actors.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public void Move(Vector3 movement)
        {
            transform.position += movement;
        }

        public void Die()
        {
            transform.gameObject.SetActive(false);
        }
    }
}