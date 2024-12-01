using System;
using Actors.Enemy.Signals;
using Actors.Player;
using Actors.Player.Signals;
using Actors.Spawning;
using Cysharp.Threading.Tasks;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using Weapon.Projectile;
using Zenject;

namespace Actors.Enemy
{
    public class EnemyPresenter : ActorPresenter<EnemyModel, EnemyView>
    {
        private PlayerPresenter _playerPresenter;
        private SignalBus _signalBus;

        private Vector3 _targetPosition;
        readonly CompositeDisposable _disposables = new CompositeDisposable();
        private IDisposable _observable;
        private bool _lockFurtherHits;
        private EnemySpawner _enemySpawner;

        [Inject]
        private void Construct(PlayerPresenter player, SignalBus signalBus, EnemySpawner enemySpawner)
        {
            _playerPresenter = player;
            _signalBus = signalBus;
            _enemySpawner = enemySpawner;
        }

        private void Start()
        {
            _signalBus.GetStream<PlayerMovedSignal>().Subscribe(x => UpdateTargetPosition(x.Position))
                .AddTo(_disposables);

            _disposables.Add(Observable.EveryUpdate().Subscribe(_ => MoveTowardsTarget()));

            // set initial target
            _targetPosition = _playerPresenter.transform.position;
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        private void UpdateTargetPosition(Vector3 target)
        {
            _targetPosition = target;
        }

        private void MoveTowardsTarget()
        {
            Assert.IsNotNull(View);

            var direction = _targetPosition - View.transform.position;
            direction.Normalize();

            View.Move(direction * Model.MoveSpeed * Time.deltaTime);
        }

        private async void OnTriggerStay(Collider other)
        {
            if (_lockFurtherHits) return;

            _lockFurtherHits = true;

            var projectilePresenter = other.GetComponent<ProjectilePresenter>();

            if (projectilePresenter == null)
            {
                _lockFurtherHits = false;
                return;
            }

            // reduce health given the projectile damage
            Model.Health -= projectilePresenter.Weapon.Damage;

            if (Model.Health <= 0)
            {
                _signalBus.Fire(new EnemyKillSignal { Model = Model });
                _enemySpawner.CleanUp(this);
                Destroy(gameObject);
                return;
            }

            await UniTask.WaitForSeconds(.25f);
            _lockFurtherHits = false;
        }

        public class Factory : PlaceholderFactory<EnemyPresenter>
        {
        }
    }
}