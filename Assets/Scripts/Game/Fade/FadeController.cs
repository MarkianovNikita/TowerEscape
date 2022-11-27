using System;
using UnityEngine;

namespace Fade
{
    public class FadeController : MonoBehaviour
    {
        public event Action FadeInCompleted;
        public event Action FadeOutCompleted;
        
        private static readonly int AnimationTriggerHashFadeIn = Animator.StringToHash("FadeIn");
        private static readonly int AnimationTriggerHashFadeOut = Animator.StringToHash("FadeOut");
        
        [SerializeField] private Animator _animator;

        public void FadeIn()
        {
            _animator.SetTrigger(AnimationTriggerHashFadeIn);
        }

        public void FadeOut()
        {
            _animator.SetTrigger(AnimationTriggerHashFadeOut);
        }

        //Called from animation
        public void OnFadeInCompleted()
        {
            FadeInCompleted?.Invoke();
        }

        //Called from animation
        public void OnFadeOutCompleted()
        {
            FadeOutCompleted?.Invoke();
        }
    }
}