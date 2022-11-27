using System;
using General;
using General.Localization;
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
            _timeLeftText.text = string.Format(
                LocalizationController.Instance.GetText("game_win_popup_text_format"),
                timePass.ToString("00"));
            
            Open();
        }
    }
}