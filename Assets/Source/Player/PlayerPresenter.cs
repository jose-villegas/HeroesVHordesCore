using UI;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private PlayerView playerView;
        
        private VirtualJoystick _virtualJoystick;

        [Inject]
        private void Construct(VirtualJoystick joystick)
        {
            _virtualJoystick = joystick;
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
           playerView?.Move(movement * Time.deltaTime);
        }
    }
}