using System;
using General;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Popups
{
    public class WinPopup : PopupBase
    {
        [SerializeField] private TMP_Text _timeLeftText;

        public void Open(float timePass)
        {
            _timeLeftText.text = $"{timePass:00} seconds";
            Open();
        }
    }
}