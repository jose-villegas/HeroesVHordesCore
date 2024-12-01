using System;
using UnityEngine;
using Zenject;

namespace Weapon.Projectile
{
    public class ProjectilePresenter : MonoBehaviour
    {
        private Vector3 _targetPosition;
        private IProjectileWeapon _weapon;
        private Vector3 _direction;

        [Inject]
        private void Construct(Vector3 targetPosition, IProjectileWeapon weapon)
        {
            _targetPosition = targetPosition;
            _weapon = weapon;
        }

        private void Start()
        {
            _direction = _targetPosition - transform.position;
            _direction.Normalize();
        }

        private void Update()
        {
            transform.position += _direction * (_weapon.Speed * Time.deltaTime);
        }

        public class Factory : PlaceholderFactory<Vector3, IProjectileWeapon, ProjectilePresenter>
        {
        }
    }
}