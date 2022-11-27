using System;
using General;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class InfoWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private ScrollRect _scroll;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _scroll.normalizedPosition = new Vector2(0, 1);
        }

        public void Close()
        {
            UiSoundsManager.Instance.PlayClickSound();
            gameObject.SetActive(false);
        }
    }
}