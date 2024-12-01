using System;
using UnityEngine;
using Zenject;

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

        public float MoveSpeed => moveSpeed;

        public float Health
        {
            get => health;
            set => health = value;
        }

        public float MaxHealth => maxHealth;

        public int Damage => damage;

        public float DamageFrequency => damageFrequency;
    }
}