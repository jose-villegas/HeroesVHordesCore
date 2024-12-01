using UnityEngine;
using Weapon.Projectile;
using Zenject;

namespace Weapon
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private ArcaneWandPresenter arcaneWandPresenter;
        [SerializeField] private ProjectileSpawner projectileSpawner;

        public override void InstallBindings()
        {
            Container.Bind<ArcaneWandPresenter>().FromInstance(arcaneWandPresenter);
            Container.Bind<ProjectileSpawner>().FromInstance(projectileSpawner);
        }
    }
}