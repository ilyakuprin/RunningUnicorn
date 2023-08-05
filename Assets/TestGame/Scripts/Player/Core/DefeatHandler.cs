using UnityEngine;

namespace RunningUnicorn
{
    public class DefeatHandler : MonoBehaviour
    {
        public delegate void Lose();
        public event Lose Lost;

        private void Defeat()
        {
            Lost?.Invoke();
            new LevelReload(this).ReloadCurrentLevel();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyAttackAnimation enemyAttackAnim))
            {
                enemyAttackAnim.AttackAnim();
                Defeat();
            }
        }
    }
}
