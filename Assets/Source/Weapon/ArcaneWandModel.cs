using System;
using UnityEngine;

namespace Weapon
{
    [Serializable]
    public class ArcaneWandModel : IProjectileWeapon
    {
        [SerializeField] private float damage;
        [SerializeField] private float frequency;
        [SerializeField] private int projectileCount;
        [SerializeField] private float lifetime;
        [SerializeField] private float _speed;

        public float Damage => damage;
        public float Frequency => frequency;
        public int ProjectileCount => projectileCount;
        public float Lifetime => lifetime;

        public float Speed => _speed;
    }
}