using Actors.Enemy;
using UnityEngine;
using Zenject;

namespace Actors.Spawning
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject enemyPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<EnemyPresenter, EnemyPresenter.Factory>().FromComponentInNewPrefab(enemyPrefab);
        }
    }
}