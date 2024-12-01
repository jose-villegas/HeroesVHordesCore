using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Weapon.Projectile;
using Zenject;

namespace Weapon
{
    public class ArcaneWandPresenter : MonoBehaviour
    {
        [SerializeField] private ArcaneWandModel arcaneWandModel;
        private ProjectileSpawner _projectileSpawner;

        public ArcaneWandModel WandModel => arcaneWandModel;

        [Inject]
        public void Construct(ProjectileSpawner projectileSpawner)
        {
            _projectileSpawner = projectileSpawner;
        }

        private void Start()
        {
            CallProjectileSpawner().Forget();
        }

        private async UniTask CallProjectileSpawner()
        {
            while (true)
            {
                _projectileSpawner.SpawnProjectiles(arcaneWandModel.ProjectileCount, arcaneWandModel.Lifetime);
                await UniTask.WaitForSeconds(arcaneWandModel.Frequency);
            }
        }
    }
}