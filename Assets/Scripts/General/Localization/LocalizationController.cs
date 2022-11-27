using System;
using Newtonsoft.Json;
using UnityEngine;

namespace General.Localization
{
    public class LocalizationController
    {
        private const string LOCALIZATION_KEY = "lang";
        
        private static LocalizationController _instance;
        public static LocalizationController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LocalizationController();
                }

                return _instance;
            }
        }

        public event Action LanguageChanged;

        private LanguageDictionary _languageDictionary;
        private string _lang;
        
        private LocalizationController()
        {
            var savedLang = PlayerPrefs.GetString(LOCALIZATION_KEY, "eng");
            ChangeLanguage(savedLang);
        }

        public void ChangeLanguage(string language)
        {
            if(_lang == language) return;

            _lang = language;
            var textAsset = Resources.Load<TextAsset>($"Localization/{_lang}");

            _languageDictionary = JsonConvert.DeserializeObject<LanguageDictionary>(textAsset.text);

            PlayerPrefs.SetString(LOCALIZATION_KEY, language);
            
            LanguageChanged?.Invoke();
        }

        public string GetText(string key)
        {
            return _languageDictionary.Dictionary[key];
        }
    }
}