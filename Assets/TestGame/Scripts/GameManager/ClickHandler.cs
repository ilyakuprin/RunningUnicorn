using System.Collections;
using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(PlayerInput))]
    public class ClickHandler : MonoBehaviour
    {
        public delegate void Fire();
        public event Fire Hit, Missed;

        private ClickCaster _clickCaster;
        private PlayerInput _playerInput;
        private PlayerShotAnimation _playerShotAnim;
        private DefeatHandler _defeatHandler;
        private WinHandler _winHandler;
        private Coroutine _clickCorutine;

        private void Awake()
        {
            _defeatHandler = FindObjectOfType<DefeatHandler>();
            _winHandler = FindObjectOfType<WinHandler>();
            _playerShotAnim = FindObjectOfType<PlayerShotAnimation>();
            _playerInput = GetComponent<PlayerInput>();
            _clickCaster = new(Camera.main);
        }

        private void Start()
        {
            StartClick();
        }

        private IEnumerator Click()
        {
            GameObject clickObj;

            while (true)
            {
                if (_playerInput.CheckPressing)
                {
                    clickObj = _clickCaster.GetGameObject(_playerInput.GetPressingPosition);

                    if (clickObj.TryGetComponent(out DeathEnemy deathEnemy))
                    {
                        _playerShotAnim.Hit += deathEnemy.Die;
                        Hit?.Invoke();
                    }
                    else
                    {
                        Missed?.Invoke();
                    }
                }

                yield return null;
            }
        }

        public void StartClick()
        {
            _clickCorutine = StartCoroutine(Click());
        }

        public void StopClick()
        {
            StopCoroutine(_clickCorutine);
        }

        private void OnEnable()
        {
            Hit += StopClick;
            Missed += StopClick;
            _defeatHandler.Lost += StopClick;
            _winHandler.Won += StopClick;

            _playerShotAnim.ContinuedMoving += StartClick;
        }

        private void OnDisable()
        {
            Hit -= StopClick;
            Missed -= StopClick;
            _defeatHandler.Lost -= StopClick;
            _winHandler.Won -= StopClick;

            _playerShotAnim.ContinuedMoving -= StartClick;
        }
    }
}
