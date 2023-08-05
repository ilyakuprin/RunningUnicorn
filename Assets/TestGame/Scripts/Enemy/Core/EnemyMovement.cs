namespace RunningUnicorn
{
    public class EnemyMovement : GameObjectMovement
    {
        private DefeatHandler _defeatHandler;

        protected override void Awake()
        {
            base.Awake();

            _defeatHandler = FindObjectOfType<DefeatHandler>();
        }

        private void OnBecameVisible()
        {
            StartMove();
            _defeatHandler.Lost += StopMove;
        }

        private void OnBecameInvisible()
        {
            StopMove();
            _defeatHandler.Lost -= StopMove;
        }
    }
}
