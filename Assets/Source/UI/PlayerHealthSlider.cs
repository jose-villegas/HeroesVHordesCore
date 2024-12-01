using Actors.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHealthSlider : ActorHealthSlider<PlayerModel>
    {
        [SerializeField] private PlayerPresenter playerPresenter;
        
        protected override PlayerModel GetActor => playerPresenter.Model;
    }
}