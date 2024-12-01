using Actors.Player.Signals;
using UI;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Actors.Player
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private PlayerView playerView;

        private VirtualJoystick _virtualJoystick;
        private SignalBus _signalBus;

        public PlayerView View => playerView;
        public PlayerModel Model => playerModel;

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

            tapStream.Subscribe(OnUserTapAndHold);
        }

        private void OnUserTapAndHold(long unit)
        {
            var speed = playerModel.MoveSpeed;
            var inputDirection = _virtualJoystick.InputDirection;
            var movement = (Vector3.right * inputDirection.x + Vector3.forward * inputDirection.z) * speed;

            Assert.IsNotNull(playerView);

            playerView.Move(movement * Time.deltaTime);
            _signalBus.Fire(new PlayerMovedSignal {Position = playerView.transform.position});
        }
    }
}