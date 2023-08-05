using UnityEngine;

namespace RunningUnicorn
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 _pressingPosition;
        private bool _pressing = false;

        public Vector3 GetPressingPosition { get => _pressingPosition; }
        public bool CheckPressing { get => _pressing; }

        private void Update()
        {
            if (Input.GetButtonDown(InputStringField.Fire1))
            {
                _pressingPosition = Input.mousePosition;
                _pressing = true;
            }
            else if (Input.touchCount > 0)
            {
                _pressingPosition = Input.GetTouch(0).position;
                _pressing = true;
            }
            else
            {
                _pressing = false;
            }
        }
    }
}
