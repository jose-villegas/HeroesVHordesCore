using System;
using UnityEngine;

namespace Actors.Player
{
    /// <summary>
    /// Model class for any player entity
    /// </summary>
    [Serializable]
    public class PlayerModel : IPlayer
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private float level;

        public float MoveSpeed => moveSpeed;

        public float Health => health;

        public float MaxHealth => maxHealth;

        public float Level => level;
    }
}