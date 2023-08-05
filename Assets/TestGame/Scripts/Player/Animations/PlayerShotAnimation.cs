using Spine;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(DefeatHandler), typeof(WinHandler), typeof(SkeletonAnimation))]
    public class PlayerShotAnimation : MonoBehaviour
    {
        public delegate void Act();
        public event Act ContinuedMoving, Hit, Missed;

        [SerializeField, SpineAnimation] private string _shoot;
        [SerializeField, SpineAnimation] private string _shootFail;

        private ClickHandler _clickHandler;
        private DefeatHandler _defeatHandler;
        private WinHandler _winHandler;

        private SkeletonAnimation _skeletonAnimation;
        private Spine.AnimationState _spineAnimationState;

        public SkeletonAnimation GetSkeletonAnimation { get => _skeletonAnimation; }

        private void Awake()
        {
            _defeatHandler = GetComponent<DefeatHandler>();
            _winHandler = GetComponent<WinHandler>();
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            _spineAnimationState = _skeletonAnimation.AnimationState;
            _clickHandler = FindObjectOfType<ClickHandler>();
        }

        private void OnEventAnim(TrackEntry trackEntry, Spine.Event e)
        {
            if (trackEntry.Animation.Name == _shoot)
            {
                Hit?.Invoke();
            }
            else if (trackEntry.Animation.Name == _shootFail)
            {
                Missed?.Invoke();
            }
        }

        private void HitAnim()
        {
            TrackEntry enty = _spineAnimationState.SetAnimation(0, _shoot, false);
            StartCoroutine(WaitTimeAnim(enty.AnimationEnd));
        }

        private void MissAnim()
        {
            TrackEntry enty = _spineAnimationState.SetAnimation(0, _shootFail, false);
            StartCoroutine(WaitTimeAnim(enty.AnimationEnd));
        }

        private IEnumerator WaitTimeAnim(float time)
        {
            yield return new WaitForSeconds(time);

            ContinuedMoving?.Invoke();
        }

        private void ClearEventContinuedMoving()
        {
            ContinuedMoving = null;
        }

        private void OnEnable()
        {
            _clickHandler.Hit += HitAnim;
            _clickHandler.Missed += MissAnim;
            _defeatHandler.Lost += ClearEventContinuedMoving;
            _winHandler.Won += ClearEventContinuedMoving;

            _skeletonAnimation.state.Event += OnEventAnim;
        }

        private void OnDisable()
        {
            _clickHandler.Hit -= HitAnim;
            _clickHandler.Missed -= MissAnim;
            _defeatHandler.Lost -= ClearEventContinuedMoving;
            _winHandler.Won -= ClearEventContinuedMoving;

            _skeletonAnimation.state.Event -= OnEventAnim;
        }
    }
}
