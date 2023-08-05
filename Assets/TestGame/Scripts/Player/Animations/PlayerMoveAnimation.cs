using Spine.Unity;
using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(PlayerShotAnimation), typeof(SkeletonAnimation))]
    public class PlayerMoveAnimation : MonoBehaviour
    {
        [SerializeField, SpineAnimation] private string _walk;

        private PlayerShotAnimation _playerShotAnima;
        private Spine.AnimationState _spineAnimationState;

        private void Awake()
        {
            _playerShotAnima = GetComponent<PlayerShotAnimation>();
            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            _spineAnimationState = skeletonAnimation.AnimationState;
        }

        private void Start()
        {
            Move();
        }

        private void Move()
        {
            _spineAnimationState.SetAnimation(0, _walk, true);
        }

        private void OnEnable()
        {
            _playerShotAnima.ContinuedMoving += Move;
        }

        private void OnDisable()
        {
            _playerShotAnima.ContinuedMoving -= Move;
        }
    }
}
