using System;

namespace Player
{
    /// <summary>
    /// Model class for any player entity
    /// </summary>
    [Serializable]
    public class PlayerModel : IPlayer
    {
        private float _moveSpeed;
        private float _health;
        private float _maxHealth;
        private float _level;

        public float MoveSpeed => _moveSpeed;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public float Level => _level;
    }
}
