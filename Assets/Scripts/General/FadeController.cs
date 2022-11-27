using System;
using UnityEngine;

namespace General
{
    public class FadeController : SingletonMonoBehaviour<FadeController>
    {
        public event Action FadeInCompleted;
        public event Action FadeOutCompleted;
        
        private static readonly int AnimationTriggerHashFadeIn = Animator.StringToHash("FadeIn");
        private static readonly int AnimationTriggerHashFadeOut = Animator.StringToHash("FadeOut");
        
        [SerializeField] private Animator _animator;

        private Action _fadeInCompleteCallback;
        private Action _fadeOutCompleteCallback;
        
        public void FadeIn(Action completeCallback = null)
        {
            _fadeInCompleteCallback = completeCallback;
            _animator.SetTrigger(AnimationTriggerHashFadeIn);
        }

        public void FadeOut(Action completeCallback = null)
        {
            _fadeOutCompleteCallback = completeCallback;
            _animator.SetTrigger(AnimationTriggerHashFadeOut);
        }

        //Called from animation
        public void OnFadeInCompleted()
        {
            _fadeInCompleteCallback?.Invoke();
            _fadeInCompleteCallback = null;
            
            FadeInCompleted?.Invoke();
        }

        //Called from animation
        public void OnFadeOutCompleted()
        {
            _fadeOutCompleteCallback?.Invoke();
            _fadeOutCompleteCallback = null;
            
            FadeOutCompleted?.Invoke();
        }
    }
}