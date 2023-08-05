using Spine.Unity;
using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(SkeletonAnimation))]
    public class EnemyWinAnimation : MonoBehaviour
    {
        [SerializeField, SpineAnimation] private string _win;

        private DefeatHandler _defeatHandler;
        private Spine.AnimationState _spineAnimationState;

        private void Awake()
        {
            _defeatHandler = FindObjectOfType<DefeatHandler>();

            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            _spineAnimationState = skeletonAnimation.AnimationState;
        }

        private void WinAnim()
        {
            _spineAnimationState.SetAnimation(0, _win, true);
        }

        public void AddWinAnim()
        {
            _defeatHandler.Lost -= WinAnim;
            _spineAnimationState.AddAnimation(0, _win, true, 0);
        }

        private void OnEnable()
        {
            _defeatHandler.Lost += WinAnim;
        }

        private void OnDisable()
        {
            _defeatHandler.Lost -= WinAnim;
        }
    }
}
