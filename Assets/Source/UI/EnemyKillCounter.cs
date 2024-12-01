using System;
using Actors.Enemy.Signals;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI
{
    public class EnemyKillCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        private SignalBus _signalBus;
        
        readonly CompositeDisposable _disposables = new CompositeDisposable();

        private int _killCount = 0;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.GetStream<EnemyKillSignal>().Subscribe(_ => IncreaseCounter())
                .AddTo(_disposables);
            
            _label.text = $"Kill #: \r\n{_killCount}";
        }
        
        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        private void IncreaseCounter()
        {
            _label.text = $"Kill #: \r\n{++_killCount}";
        }
    }
}