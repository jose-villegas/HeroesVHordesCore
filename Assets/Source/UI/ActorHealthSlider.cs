using Actors;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class ActorHealthSlider<T1> : MonoBehaviour where T1 : IActor
    {
        [SerializeField] private Slider healthSlider;

        protected abstract T1 GetActor { get; }

        private void Update()
        {
            UpdateSlider(GetActor);
        }

        private void UpdateSlider(IActor actor)
        {
            healthSlider.value = actor.Health / actor.MaxHealth;
        }
    }
}