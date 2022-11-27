using UnityEngine;

namespace Popups
{
    public class PopupBase : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int AnimationTriggerHashOpen = Animator.StringToHash("Open");
        
        protected AudioSource AudioSource;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            AudioSource = GetComponent<AudioSource>();
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            _animator.SetTrigger(AnimationTriggerHashOpen);
        }
    }
}