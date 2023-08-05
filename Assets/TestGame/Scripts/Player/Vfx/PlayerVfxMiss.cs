namespace RunningUnicorn
{
    public class PlayerVfxMiss : PlayerVfx
    {
        private ClickHandler _clickHandler;

        protected override void Awake()
        {
            base.Awake();

            _clickHandler = FindObjectOfType<ClickHandler>();
        }

        private void OnEnable()
        {
            _clickHandler.Missed += VfxPlay;
        }

        private void OnDisable()
        {
            _clickHandler.Missed -= VfxPlay;
        }
    }
}
