using Actors.Enemy.Signals;
using Actors.Player;
using Actors.Player.Signals;
using Actors.Spawning;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Map
{
    public class MapInstaller : MonoInstaller
    {
        [SerializeField] private PlayerPresenter playerPresenter;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private Camera camera;
        
        public override void InstallBindings()
        {
            Assert.IsNotNull(playerPresenter);
            
            // signals available
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerMovedSignal>();
            Container.DeclareSignal<PlayerExperienceIncreaseSignal>();
            Container.DeclareSignal<PlayerLevelIncreaseSignal>();
            Container.DeclareSignal<EnemyKillSignal>();
            
            // context dependencies
            Container.Bind<PlayerPresenter>().FromInstance(playerPresenter);
            Container.Bind<EnemySpawner>().FromInstance(enemySpawner);
            Container.Bind<Camera>().FromInstance(camera);
        }
    }
}