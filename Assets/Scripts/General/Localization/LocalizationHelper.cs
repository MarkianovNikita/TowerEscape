using System;
using TMPro;
using UnityEngine;

namespace General.Localization
{
    public class LocalizationHelper : MonoBehaviour
    {
        [SerializeField] private string _localizationKey;
        private TMP_Text _text;
        
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            UpdateText();

            LocalizationController.Instance.LanguageChanged += UpdateText;
        }

        private void OnDisable()
        {
            LocalizationController.Instance.LanguageChanged -= UpdateText;
        }

        private void UpdateText()
        {
            _text.text = LocalizationController.Instance.GetText(_localizationKey);
        }
    }
}