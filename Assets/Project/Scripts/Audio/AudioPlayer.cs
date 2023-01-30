using UnityEngine;

namespace Project.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource, effectsSource;

        public void PlayEffect(AudioTrack audioTrack)
        {
            effectsSource.PlayOneShot(audioTrack.AudioClip);
        }

        public void PlayMusic(AudioTrack audioTrack)
        {
            if (!audioTrack)
            {
                StopMusic();
                return;
            }

            if (musicSource.clip == audioTrack.AudioClip)
            {
                if (musicSource.isPlaying) return;
            }
            var text = musicSource.clip ? musicSource.clip.ToString() : "null";
            Debug.Log($"Changing from {text} to {audioTrack.AudioClip}");
            musicSource.clip = audioTrack.AudioClip;
            musicSource.Play();
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void PauseMusic()
        {
            musicSource.Pause();
        }

        public void UnPauseMusic()
        {
            musicSource.UnPause();
        }

        public void ToggleMusic()
        {
            musicSource.mute = !musicSource.mute;
        }

        public void ToggleEffects()
        {
            effectsSource.mute = !effectsSource.mute;
        }
    }

}