using TMPro;
using UnityEngine;

namespace Game.Door
{
    public class LockDialogView : MonoBehaviour
    {
        private static readonly int AnimationTriggerHashShow = Animator.StringToHash("Show");
        private static readonly int AnimationTriggerHashHide = Animator.StringToHash("Hide");

        [SerializeField] private TMP_Text _orderText;

        private string _orderTextFormat;
        
        private Animator _animator;
        
        public bool IsOpen { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _orderTextFormat = _orderText.text;
        }

        public void Show(string orderText)
        {
            _orderText.text = orderText;
            
            _animator.SetTrigger(AnimationTriggerHashShow);

            IsOpen = true;
        }

        public void Hide()
        {
            _animator.SetTrigger(AnimationTriggerHashHide);

            IsOpen = false;
        }
    }
}