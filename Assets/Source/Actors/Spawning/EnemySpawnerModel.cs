using System;
using UnityEngine;

namespace Actors.Spawning
{
    [Serializable]
    public class EnemySpawnerModel : IActorSpawner
    {
        [SerializeField] private float frequency;
        [SerializeField] private int spawnPerCycle;
        [SerializeField] private float delay;
        [SerializeField] private float lifetime;
        
        /// <summary>
        /// Minimum and maximum possible distance from the player to spawn
        /// </summary>
        [SerializeField] private Vector2 distanceFromPlayer;

        public float Frequency => frequency;
        public int SpawnPerCycle => spawnPerCycle;
        public float Delay => delay;
        public float Lifetime => lifetime;
        public Vector2 DistanceFromPlayer => distanceFromPlayer;
    }
}