using UnityEngine;

namespace General
{
    public class UiSoundsManager : SingletonMonoBehaviour<UiSoundsManager>
    {
        [SerializeField] private AudioSource _audioSource;
        
        public void PlayClickSound()
        {
            _audioSource.Play();
        }
    }
}