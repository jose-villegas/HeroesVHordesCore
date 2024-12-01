using System;
using Actors.Enemy;
using Actors.Enemy.Signals;
using Actors.Player.Signals;
using Cysharp.Threading.Tasks;
using Extensions;
using UI;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Actors.Player
{
    public class PlayerPresenter : ActorPresenter<PlayerModel, PlayerView>
    {
        private VirtualJoystick _virtualJoystick;
        private SignalBus _signalBus;
        private bool _lockedForDamage;

        readonly CompositeDisposable _disposables = new CompositeDisposable();

        [Inject]
        private void Construct(VirtualJoystick joystick, SignalBus signalBus)
        {
            _virtualJoystick = joystick;
            _signalBus = signalBus;
        }

        public void Start()
        {
            // listen to click hold for movement
            var tapStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0) || Input.GetMouseButton(0));
            _signalBus.GetStream<EnemyKillSignal>().Subscribe(x => OnEnemyKill(x.Model))
                .AddTo(_disposables);

            tapStream.Subscribe(OnUserTapAndHold).AddTo(_disposables);
        }

        private void OnEnemyKill(EnemyModel model)
        {
            var previousExperience = Model.Experience;
            Model.Experience += model.ExperienceReward;
            
            _signalBus.Fire(new PlayerExperienceIncreaseSignal(previousExperience, Model));

            // check if we have level up
            var nextLevel = Model.Level + 5;
            // required experience
            var requiredExp = Fibonacci.Calculate(nextLevel);

            // we have leveled up
            if (Model.Experience >= requiredExp)
            {
                Model.Level++;
                Model.Experience = 0;
                _signalBus.Fire(new PlayerLevelIncreaseSignal(Model));
            }
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        private void OnUserTapAndHold(long unit)
        {
            var speed = Model.MoveSpeed;
            var inputDirection = _virtualJoystick.InputDirection;
            var movement = (Vector3.right * inputDirection.x + Vector3.forward * inputDirection.z) * speed;

            Assert.IsNotNull(View);

            View.Move(movement * Time.deltaTime);
            _signalBus.Fire(new PlayerMovedSignal(View.transform.position));
        }

        private async void OnTriggerEnter(Collider other)
        {
            var enemyPresenter = other.attachedRigidbody.GetComponent<EnemyPresenter>();

            if (enemyPresenter == null || _lockedForDamage) return;

            _lockedForDamage = true;

            Model.Health -= enemyPresenter.Model.Damage;

            // Game Over
            if (Model.Health <= 0)
            {
                _lockedForDamage = false;
                QuitGame();
                return;
            }

            await UniTask.WaitForSeconds(enemyPresenter.Model.DamageFrequency);

            _lockedForDamage = false;
        }

        public void QuitGame()
        {
            // save any game data here
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}