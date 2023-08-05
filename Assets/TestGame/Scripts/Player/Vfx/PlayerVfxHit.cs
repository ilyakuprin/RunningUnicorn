namespace RunningUnicorn
{
    public class PlayerVfxHit : PlayerVfx
    {
        private PlayerShotAnimation _playerShotAnim;

        protected override void Awake()
        {
            base.Awake();

            _playerShotAnim = FindObjectOfType<PlayerShotAnimation>();
        }

        private void OnEnable()
        {
            _playerShotAnim.Hit += VfxPlay;
        }

        private void OnDisable()
        {
            _playerShotAnim.Hit -= VfxPlay;
        }
    }
}
