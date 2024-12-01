using System;
using Actors.Player;
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
        private PlayerPresenter _playerPresenter;

        public ArcaneWandModel WandModel => arcaneWandModel;

        [Inject]
        public void Construct(ProjectileSpawner projectileSpawner, PlayerPresenter playerPresenter)
        {
            _projectileSpawner = projectileSpawner;
            _playerPresenter = playerPresenter;
        }

        private void Start()
        {
            CallProjectileSpawner().Forget();
        }

        private async UniTask CallProjectileSpawner()
        {
            while (true)
            {
                var extra = _playerPresenter.Model.Level / 2;

                _projectileSpawner.SpawnProjectiles(arcaneWandModel.ProjectileCount + extra, arcaneWandModel.Lifetime);
                await UniTask.WaitForSeconds(arcaneWandModel.Frequency);
            }
        }
    }
}