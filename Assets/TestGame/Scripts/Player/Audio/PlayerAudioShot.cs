using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class PlayerAudioShot : MonoBehaviour
    {
        private AudioSource _audioSource;

        protected virtual void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        protected void AudioPlay()
        {
            _audioSource.Play();
        }
    }
}
