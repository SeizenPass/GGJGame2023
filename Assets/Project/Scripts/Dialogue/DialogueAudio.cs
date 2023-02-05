using System;
using UnityEngine;

namespace Project.Dialogue
{
    public class DialogueAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            audioSource.Play();
            audioSource.Pause();
        }

        public void Speak()
        {
            audioSource.UnPause();
        }

        public void Stop()
        {
            audioSource.Pause();
        }
    }
}