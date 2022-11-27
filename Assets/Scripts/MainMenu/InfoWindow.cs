using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

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
            gameObject.SetActive(false);
        }
    }
}