using System;
using General.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class LocalizationSelector : MonoBehaviour
    {
        private const string LOCALIZATION_KEY = "eng";
        
        [SerializeField] private Button _uaButton;
        [SerializeField] private Button _engButton;

        private void Awake()
        {
            _uaButton.onClick.AddListener(() => OnLanguageChangeClicked("ua"));
            _engButton.onClick.AddListener(() => OnLanguageChangeClicked("eng"));
        }

        private void OnLanguageChangeClicked(string langKey)
        {
            LocalizationController.Instance.ChangeLanguage(langKey);
        }
    }
}