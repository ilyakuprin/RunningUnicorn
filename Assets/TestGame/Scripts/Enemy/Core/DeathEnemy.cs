using UnityEngine;

namespace RunningUnicorn
{
    public class DeathEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject _explosion;
        private PlayerShotAnimation _playerShotAnimation;

        private void Awake()
        {
            _playerShotAnimation = FindObjectOfType<PlayerShotAnimation>();
        }

        public void Die()
        {
            _explosion.transform.parent = null;
            _explosion.SetActive(true);

            Destroy(gameObject);
        }

        private void OnDisable()
        {
            _playerShotAnimation.Hit -= Die;
        }
    }
}
