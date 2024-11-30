using UnityEngine;
using Zenject;

namespace UI
{
    public class Follow3DObject : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        private RectTransform _rectTransform;
        private Vector2 _sourceAnchoredPosition;
        private Camera _mapCamera;

        [Inject]
        private void Construct(Camera camera)
        {
            _mapCamera = camera;
        }
        
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _sourceAnchoredPosition = _rectTransform.anchoredPosition;
        }

        private void Update()
        {
            var screenPoint = _mapCamera.WorldToScreenPoint(target.position);
            screenPoint.x = screenPoint.x - Screen.width * 0.5f + _sourceAnchoredPosition.x;
            screenPoint.y = screenPoint.y - Screen.height * 0.5f + _sourceAnchoredPosition.y;

            // change rect position to screen position from target
            _rectTransform.anchoredPosition = screenPoint;
        }
    }
}