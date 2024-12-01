using System;
using Actors.Enemy;
using UnityEngine;

namespace UI
{
    public class EnemyHealthSlider : ActorHealthSlider<EnemyModel>
    {
        [SerializeField] private EnemyPresenter enemyPresenter;

        protected override EnemyModel GetActor => enemyPresenter.Model;
    }
}