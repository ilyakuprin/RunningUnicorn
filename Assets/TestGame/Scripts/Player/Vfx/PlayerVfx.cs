using UnityEngine;

namespace RunningUnicorn
{
    [RequireComponent(typeof(ParticleSystem))]
    public abstract class PlayerVfx : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        protected virtual void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        protected void VfxPlay()
        {
            _particleSystem.Play();
        }
    }
}
