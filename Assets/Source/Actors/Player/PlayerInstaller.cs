using UI;
using UnityEngine;
using Zenject;

namespace Actors.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private VirtualJoystick virtualJoystick;

        public override void InstallBindings()
        {
            Container.Bind<VirtualJoystick>().FromInstance(virtualJoystick);
        }
    }
}