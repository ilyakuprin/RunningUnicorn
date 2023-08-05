using System.Collections;
using UnityEngine;

namespace RunningUnicorn
{
    public class CloudTeleportation : MonoBehaviour
    {
        private float _leftBorderX;
        private float _rightBorderX;
        private GameObjectMovement _gameObjectMovement;

        private void Awake()
        {
            _gameObjectMovement = transform.parent.GetComponent<GameObjectMovement>();

            CloudTeleportationBorder border = transform.parent.GetComponent<CloudTeleportationBorder>();
            _leftBorderX = border.GetLeft;
            _rightBorderX = border.GetRigt;
        }

        private void Start()
        {
            StartCheckTeleport(_gameObjectMovement.GetDirection);
        }

        private IEnumerator TeleportToLeft()
        {
            while (true)
            {
                if (transform.position.x > _rightBorderX)
                {
                    transform.position = new Vector2(_leftBorderX, transform.position.y);
                }
                yield return null;
            }
        }

        private IEnumerator TeleportToRight()
        {
            while (true)
            {
                if (transform.position.x < _leftBorderX)
                {
                    transform.position = new Vector2(_rightBorderX, transform.position.y);
                }
                yield return null;
            }
        }

        private void StartCheckTeleport(Vector3 direction)
        {
            if (direction == Vector3.left)
            {
                StartCoroutine(TeleportToRight());
            }
            else
            {
                StartCoroutine(TeleportToLeft());
            }
        }
    }
}
