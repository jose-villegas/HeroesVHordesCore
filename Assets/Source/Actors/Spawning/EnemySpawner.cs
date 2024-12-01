using System.Collections.Generic;
using Actors.Enemy;
using Actors.Player;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Actors.Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerModel spawnerModel;

        private EnemyPresenter.Factory _enemyFactory;
        private PlayerPresenter _playerPresenter;

        private List<EnemyPresenter> _enemies = new List<EnemyPresenter>();

        public List<EnemyPresenter> Enemies => _enemies;

        [Inject]
        private void Construct(EnemyPresenter.Factory enemyFactory, PlayerPresenter player)
        {
            _enemyFactory = enemyFactory;
            _playerPresenter = player;
        }

        private void Start()
        {
            SpawnEnemies().Forget();
        }

        public void CleanUp(EnemyPresenter presenter)
        {
            _enemies.RemoveAll(x => x == presenter);
        }

        private async UniTask SpawnEnemies()
        {
            var startingTime = Time.time;
            
            Assert.IsNotNull(spawnerModel);

            if (spawnerModel.Delay > 0f)
            {
                await UniTask.WaitForSeconds(spawnerModel.Delay);
            }

            while (true)
            {
                var extra = Mathf.Sqrt(_playerPresenter.Model.Level);
                
                for (int i = 0; i < spawnerModel.SpawnPerCycle + extra; i++)
                {
                    var result = _enemyFactory.Create();
                    var playerPosition = _playerPresenter.View.transform.position;

                    // create random direction vector
                    var direction = Vector3.right * UnityEngine.Random.Range(-1f, 1f) +
                                    Vector3.forward * UnityEngine.Random.Range(-1f, 1f);
                    direction.Normalize();

                    // choose a random distance from the allowed distance
                    var distance = UnityEngine.Random.Range(spawnerModel.DistanceFromPlayer.x,
                        spawnerModel.DistanceFromPlayer.y);

                    // multiply by allowed distance from player
                    direction *= distance;
                    
                    // set instance position
                    result.transform.position = playerPosition + direction;
                    
                    // register spawned enemy
                    _enemies.Add(result);
                }

                await UniTask.WaitForSeconds(spawnerModel.Frequency);

                // cancel in case it's requested
                var currentTime = Time.time;

                if (spawnerModel.Lifetime > 0)
                {
                    if (currentTime - startingTime > spawnerModel.Lifetime) return;
                }
            }
        }
    }
}