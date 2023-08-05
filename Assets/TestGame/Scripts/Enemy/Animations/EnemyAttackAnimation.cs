using Spine.Unity;
using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(EnemyWinAnimation), typeof(SkeletonAnimation))]
    public class EnemyAttackAnimation : MonoBehaviour
    {
        [SerializeField, SpineAnimation] private string _attack;

        private EnemyWinAnimation _enemyWinAnimation;
        private Spine.AnimationState _spineAnimationState;

        private void Awake()
        {
            _enemyWinAnimation = GetComponent<EnemyWinAnimation>();

            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            _spineAnimationState = skeletonAnimation.AnimationState;
        }

        public void AttackAnim()
        {
            _spineAnimationState.SetAnimation(0, _attack, false);
            _enemyWinAnimation.AddWinAnim();
        }
    }
}
