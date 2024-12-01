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
        [SerializeField] private int level;
        [SerializeField] private int experience;

        public float MoveSpeed => moveSpeed;

        public float Health
        {
            get => health;
            set => health = value;
        }

        public float MaxHealth => maxHealth;

        public int Level
        {
            get => level;
            set => level = value;
        }

        public int Experience
        {
            get => experience;
            set => experience = value;
        }
    }
}