using System;
using Actors.Player;
using Actors.Player.Signals;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Actors.Enemy
{
    public class EnemyPresenter : MonoBehaviour
    {
        [SerializeField] private EnemyModel enemyModel;
        [SerializeField] private EnemyView enemyView;

        private PlayerPresenter _playerPresenter;
        private SignalBus _signalBus;

        private Vector3 _targetPosition;
        readonly CompositeDisposable _disposables = new CompositeDisposable();

        public EnemyView View => enemyView;

        [Inject]
        private void Construct(PlayerPresenter player, SignalBus signalBus)
        {
            _playerPresenter = player;
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.GetStream<PlayerMovedSignal>().Subscribe(x => UpdateTargetPosition(x.Position))
                .AddTo(_disposables);

            Observable.EveryUpdate().Subscribe(_ => MoveTowardsTarget());

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
            Assert.IsNotNull(enemyView);

            var direction = _targetPosition - enemyView.transform.position;
            direction.Normalize();

            enemyView.Move(direction * enemyModel.MoveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
        }

        public class Factory : PlaceholderFactory<EnemyPresenter>
        {
        }
    }
}