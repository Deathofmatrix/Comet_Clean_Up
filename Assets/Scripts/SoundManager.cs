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
        [SerializeField] private AudioSource musicSource;

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
        private void Start()
        {
            PlayMusic();
        }

        public void PlaySound(AudioClip clip)
        {
            _effectsSource.PlayOneShot(clip);
        }

        public void PlayMusic()
        {
            Debug.Log("preplay");
            if (musicSource.isPlaying) return;
            Debug.Log("postplay");
            musicSource.Play();
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void ChangeMasterVolume(float value)
        {
            AudioListener.volume = value;
        }
    }
}
