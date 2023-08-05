using System.Collections;
using UnityEngine;

namespace RunningUnicorn
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField, Range(0, 1)] private float _parallaxStrength;
        private Vector3 _targetPreviousPosition;

        private void Awake()
        {
            if (_followTarget != null)
            {
                _followTarget = Camera.main.transform;
            }

            _targetPreviousPosition = _followTarget.position;
        }

        private void Start()
        {
            StartCoroutine(ApplyParallax());
        }

        private IEnumerator ApplyParallax()
        {
            while (true)
            {
                Vector3 delta = _followTarget.position - _targetPreviousPosition;

                _targetPreviousPosition = _followTarget.position;
                transform.position += delta * _parallaxStrength;

                yield return null;
            }
        }
    }
}
