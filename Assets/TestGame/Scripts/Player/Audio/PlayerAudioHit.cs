namespace RunningUnicorn
{
    public class PlayerAudioHit : PlayerAudioShot
    {
        private ClickHandler _clickHandler;

        protected override void Awake()
        {
            base.Awake();

            _clickHandler = FindObjectOfType<ClickHandler>();
        }

        private void OnEnable()
        {
            _clickHandler.Hit += AudioPlay;
        }

        private void OnDisable()
        {
            _clickHandler.Hit -= AudioPlay;
        }
    }
}
