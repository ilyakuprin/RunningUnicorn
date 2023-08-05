namespace RunningUnicorn
{
    public class PlayerAudioMiss : PlayerAudioShot
    {
        private ClickHandler _clickHandler;

        protected override void Awake()
        {
            base.Awake();

            _clickHandler = FindObjectOfType<ClickHandler>();
        }

        private void OnEnable()
        {
            _clickHandler.Missed += AudioPlay;
        }

        private void OnDisable()
        {
            _clickHandler.Missed -= AudioPlay;
        }
    }
}
