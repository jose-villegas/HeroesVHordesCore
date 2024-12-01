using System.Linq;
using Actors.Player;
using Actors.Spawning;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Weapon.Projectile
{
    public class ProjectileSpawner : MonoBehaviour
    {
        private ProjectilePresenter.Factory _projectileFactory;
        private PlayerPresenter _playerPresenter;
        private EnemySpawner _enemySpawner;
        private ArcaneWandPresenter _arcaneWandPresenter;

        [Inject]
        private void Construct(ProjectilePresenter.Factory projectileFactory, PlayerPresenter player,
            EnemySpawner enemySpawner, ArcaneWandPresenter arcaneWandPresenter)
        {
            _projectileFactory = projectileFactory;
            _playerPresenter = player;
            _enemySpawner = enemySpawner;
            _arcaneWandPresenter = arcaneWandPresenter;
        }

        public void SpawnProjectiles(int projectileCount, float lifeTime)
        {
            var playerPosition = _playerPresenter.View.transform.position;

            // look for the nearest enemy within the current enemy list
            var enemies = _enemySpawner.Enemies;

            if (enemies == null || enemies.Count == 0) return;

            var sortedEnemies = enemies
                .OrderBy(x => Vector3.SqrMagnitude(playerPosition - x.transform.position))
                .ToList();

            for (int i = sortedEnemies.Count() - 1; i >= 0 || sortedEnemies.Count() - i >= projectileCount; i--)
            {
                var instance = _projectileFactory.Create(sortedEnemies[i].View.transform.position,
                    _arcaneWandPresenter.WandModel);
                instance.transform.parent = null;
                Destroy(instance.gameObject, lifeTime);
            }
        }
    }
}