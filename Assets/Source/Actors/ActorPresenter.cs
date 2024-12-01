using UnityEngine;

namespace Actors
{
    public class ActorPresenter<T1, T2> : MonoBehaviour where T1 : IActor where T2: MonoBehaviour
    {
        [SerializeField] private T1 model;
        [SerializeField] private T2 view;
    
        public T1 Model => model;
        public T2 View => view;
    }
}