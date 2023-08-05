using System;
using System.Collections;
using UnityEngine;

namespace RunningUnicorn
{
    public abstract class GameObjectMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _motionObject;
        [SerializeField, Range(0, 5)] private float _speed;
        [SerializeField] private Direction _direction = Direction.left;
        private Vector3 _vectorDirection;
        private Coroutine _moveCoroutine;

        public Vector3 GetDirection { get => _vectorDirection; }

        protected virtual void Awake()
        {
            _vectorDirection = new GettingDirectionMovement().GetDirection(_direction);

            if (_motionObject == null)
            {
                _motionObject = gameObject;
            }
        }

        private IEnumerator Move()
        {
            while (true)
            {
                _motionObject.transform.position += _vectorDirection * _speed * Time.deltaTime;
                yield return null;
            }
        }

        protected void StopMove()
        {
            StopCoroutine(_moveCoroutine);
        }

        protected void StartMove()
        {
            _moveCoroutine = StartCoroutine(Move());
        }
    }
}
