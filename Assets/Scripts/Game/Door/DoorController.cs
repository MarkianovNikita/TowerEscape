using System;
using Items;
using UnityEngine;

namespace Door
{
    public class DoorController : MonoBehaviour
    {
        private Animator _animator;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void Open()
        {
            _animator.SetTrigger("Open");
            _audioSource.Play();
        }
    }
}