using System;
using UnityEngine;

namespace Actors.Enemy
{
    [Serializable]
    public class EnemyModel : IEnemy
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private int damage;
        [SerializeField] private float damageFrequency;
        [SerializeField] private float influenceRadius;

        public float MoveSpeed => moveSpeed;

        public float Health => health;

        public float MaxHealth => maxHealth;

        public int Damage => damage;

        public float DamageFrequency => damageFrequency;

        public float InfluenceRadius => influenceRadius;
    }
}