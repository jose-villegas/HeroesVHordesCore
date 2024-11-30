using Actors.Player;
using Actors.Player.Signals;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Map
{
    public class MapInstaller : MonoInstaller
    {
        [SerializeField] private PlayerPresenter playerPresenter;
        
        public override void InstallBindings()
        {
            Assert.IsNotNull(playerPresenter);
            
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerMovedSignal>();
            
            Container.Bind<PlayerPresenter>().FromInstance(playerPresenter);
        }
    }
}