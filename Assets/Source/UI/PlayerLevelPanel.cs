using System;
using Actors.Enemy.Signals;
using Actors.Player;
using Actors.Player.Signals;
using Extensions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class PlayerLevelPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerLevelText;
        [SerializeField] private Slider playerLevelSlider;
        private SignalBus _signalBus;
        
        readonly CompositeDisposable _disposables = new CompositeDisposable();

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.GetStream<PlayerLevelIncreaseSignal>().Subscribe(x => OnPlayerLevel(x.Model))
                .AddTo(_disposables);
            _signalBus.GetStream<PlayerExperienceIncreaseSignal>().Subscribe(x => OnPlayerExperience(x.Model))
                .AddTo(_disposables);
            
            playerLevelText.text = $"Level: 1";
            playerLevelSlider.maxValue = Fibonacci.Calculate(6);
            playerLevelSlider.value = 0;
        }

        private void OnPlayerExperience(PlayerModel model)
        {
            playerLevelSlider.maxValue = Fibonacci.Calculate(model.Level + 5);
            playerLevelSlider.value = model.Experience;
        }

        private void OnPlayerLevel(PlayerModel model)
        {
            playerLevelText.text = $"Level: {model.Level}";
            OnPlayerExperience(model);
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}