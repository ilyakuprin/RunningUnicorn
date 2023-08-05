using Spine.Unity;
using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(WinHandler), typeof(SkeletonAnimation))]
    public class PlayerIdleAnimation : MonoBehaviour
    {
        [SerializeField, SpineAnimation] private string _idle;

        private WinHandler _winHandler;
        private Spine.AnimationState _spineAnimationState;

        private void Awake()
        {
            _winHandler = GetComponent<WinHandler>();

            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            _spineAnimationState = skeletonAnimation.AnimationState;
        }

        private void IdleAnim()
        {
            _spineAnimationState.SetAnimation(0, _idle, false);
        }

        private void OnEnable()
        {
            _winHandler.Won += IdleAnim;
        }

        private void OnDisable()
        {
            _winHandler.Won -= IdleAnim;
        }
    }
}
