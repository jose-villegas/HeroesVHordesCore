using Actors.Enemy;
using UnityEngine;
using Zenject;

namespace Weapon.Projectile
{
    public class ProjectileSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject projectilePrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<Vector3, IProjectileWeapon, ProjectilePresenter, ProjectilePresenter.Factory>()
                .FromComponentInNewPrefab(projectilePrefab);
        }
    }
}