using Actors.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EnemyHealthSlider : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private EnemyPresenter enemyPresenter;
        
        private void Update()
        {
            var data = enemyPresenter.Model;
            healthSlider.value = data.Health / data.MaxHealth;
        }
    }
}