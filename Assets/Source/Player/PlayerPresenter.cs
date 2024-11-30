using R3;
using UI;
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
            var tapStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));

            tapStream.Subscribe(OnUserTapAndHold);
        }

        private void OnUserTapAndHold(Unit unit)
        {
            var speed = playerModel.MoveSpeed;
            var movement = (Vector3.right + Vector3.forward) * speed;
           playerView?.Move(movement);
        }
    }
}