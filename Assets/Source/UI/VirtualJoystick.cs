using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image background;
        [SerializeField] private Image handle;

        public Vector3 InputDirection { get; set; }

        private void Start()
        {
            // get middle point horizontally on screen
            var middle = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            middle.x = middle.x - background.rectTransform.sizeDelta.x / 2f;
            middle.y = 0;
            background.rectTransform.anchoredPosition = middle;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var isWithinCanvas = RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform,
                eventData.position, eventData.pressEventCamera, out var position);

            if (isWithinCanvas)
            {
                // get the touch position
                position.x = (position.x / background.rectTransform.sizeDelta.x);
                position.y = (position.y / background.rectTransform.sizeDelta.y);

                // calculate the move position
                var x = (background.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
                var y = (background.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

                // Get the input position
                InputDirection = new Vector3(x, 0, y);
                InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

                // move the handle
                handle.rectTransform.anchoredPosition = new Vector3(
                    InputDirection.x * (background.rectTransform.sizeDelta.x / 3),
                    InputDirection.z * (background.rectTransform.sizeDelta.y / 3));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // reset handle
            InputDirection = Vector3.zero;
            handle.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}