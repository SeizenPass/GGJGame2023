using UnityEngine;
using Zenject;

namespace Project.Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [Inject]
        private AudioPlayer _audioPlayer;
    
        [SerializeField] private AudioTrack track;
        [SerializeField] private bool playOnStart;
        
        private void Start()
        {
            if (playOnStart) Play();
        }

        public void Play()
        {
            _audioPlayer.PlayMusic(track);
        }

        public void Play(AudioTrack audioTrack)
        {
            _audioPlayer.PlayMusic(audioTrack);
        }

        public void StopMusic()
        {
            _audioPlayer.StopMusic();
        }
    }

}