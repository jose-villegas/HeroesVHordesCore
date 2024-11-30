using System;
using UnityEngine;

namespace Actors.Spawning
{
    [Serializable]
    public class EnemySpawnerModel : IActorSpawner
    {
        [SerializeField] private float _frequency;
        [SerializeField] private int _spawnPerCycle;
        [SerializeField] private float _delay;
        [SerializeField] private float _lifetime;

        public float Frequency => _frequency;
        public int SpawnPerCycle => _spawnPerCycle;
        public float Delay => _delay;
        public float Lifetime => _lifetime;
    }
}