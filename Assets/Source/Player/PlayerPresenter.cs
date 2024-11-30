using System;
using R3;
using UnityEngine;

namespace Player
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private PlayerView playerView;

        public void Start()
        {
            // listen to click hold for movement
            var tapStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));

            tapStream.Subscribe(OnUserTapAndHold);
        }

        private void OnUserTapAndHold(Unit unit)
        {
           playerView?.Move(Vector3.back);
        }
    }
}