using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CometCleanUP
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [SerializeField] private AudioSource m_AudioSource, _effectsSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public void PlaySound(AudioClip clip)
        {
            _effectsSource.PlayOneShot(clip);
        }

        public void ChangeMasterVolume(float value)
        {
            AudioListener.volume = value;
        }
    }
}
