using UI;
using UnityEngine;
using Zenject;

namespace Actors.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private VirtualJoystick virtualJoystick;
        [SerializeField] private PlayerPresenter playerPresenter;
        
        public override void InstallBindings()
        {
            Container.Bind<VirtualJoystick>().FromInstance(virtualJoystick);
            Container.Bind<IActor>().FromInstance(playerPresenter.Model);
        }
    }
}