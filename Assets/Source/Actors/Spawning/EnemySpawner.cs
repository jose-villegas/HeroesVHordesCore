using Actors.Enemy;
using UnityEngine;
using Zenject;

namespace Actors.Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerModel spawnerModel;
        
        private EnemyPresenter.Factory _enemyFactory;

        [Inject]
        private void Construct(EnemyPresenter.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {
            _enemyFactory.Create();
        }
    }
}