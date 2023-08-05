using Spine.Unity;
using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(DefeatHandler), typeof(SkeletonAnimation))]
    public class PlayerDeathAnimation : MonoBehaviour
    {
        [SerializeField, SpineAnimation] private string _loose;

        private DefeatHandler _defeatHandler;
        private Spine.AnimationState _spineAnimationState;

        private void Awake()
        {
            _defeatHandler = GetComponent<DefeatHandler>();

            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            _spineAnimationState = skeletonAnimation.AnimationState;
        }

        private void DieAnim()
        {
            _spineAnimationState.SetAnimation(0, _loose, false);
        }

        private void OnEnable()
        {
            _defeatHandler.Lost += DieAnim;
        }

        private void OnDisable()
        {
            _defeatHandler.Lost += DieAnim;
        }
    }
}
