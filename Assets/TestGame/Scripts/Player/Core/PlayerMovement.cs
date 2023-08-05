using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(PlayerShotAnimation), typeof(DefeatHandler), typeof(WinHandler))]
    public class PlayerMovement : GameObjectMovement
    {
        private ClickHandler _clickHandler;
        private PlayerShotAnimation _playerShotAnim;
        private DefeatHandler _defeatHandler;
        private WinHandler _winHandler;

        protected override void Awake()
        {
            base.Awake();

            _clickHandler = FindObjectOfType<ClickHandler>();
            _playerShotAnim = GetComponent<PlayerShotAnimation>();
            _defeatHandler = GetComponent<DefeatHandler>();
            _winHandler = GetComponent<WinHandler>();
        }

        private void Start()
        {
            StartMove();
        }

        private void OnEnable()
        {
            _clickHandler.Hit += StopMove;
            _clickHandler.Missed += StopMove;
            _defeatHandler.Lost += StopMove;
            _winHandler.Won += StopMove;

            _playerShotAnim.ContinuedMoving += StartMove;
        }

        private void OnDisable()
        {
            _clickHandler.Hit -= StopMove;
            _clickHandler.Missed -= StopMove;
            _defeatHandler.Lost -= StopMove;
            _winHandler.Won -= StopMove;

            _playerShotAnim.ContinuedMoving -= StartMove;
        }
    }
}
