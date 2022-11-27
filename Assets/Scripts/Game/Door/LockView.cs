using System;
using UnityEngine;

namespace Door
{
    public class LockView : MonoBehaviour
    {
        [SerializeField] private GameObject _textObj;

        private void Awake()
        {
            HideText();
        }

        public void ShowText()
        {
            _textObj.SetActive(true);
        }

        public void HideText()
        {
            _textObj.SetActive(false);
        }
    }
}