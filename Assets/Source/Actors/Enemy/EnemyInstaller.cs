using UnityEngine;
using Zenject;

namespace Actors.Enemy
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyPresenter enemyPresenter;

        public override void InstallBindings()
        {
            Container.Bind<IActor>().FromInstance(enemyPresenter.Model);
        }
    }
}