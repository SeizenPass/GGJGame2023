using UnityEngine;
using Zenject;

namespace Project.Audio
{
    public class SoundPlayer : MonoBehaviour
    {
        [Inject]
        private AudioPlayer _audioPlayer;

        public void PlaySound(AudioTrack audioTrack)
        {
            _audioPlayer.PlayEffect(audioTrack);
        }

        public void PlayRandomSound(AudioTrackCollection audioTrackCollection)
        {
            if (!audioTrackCollection)
            {
                Debug.LogWarning("Audio collection is null.");
                return;
            }
            if (audioTrackCollection.AudioTracks.Length == 0)
            {
                Debug.LogWarning("Audio collection is empty.");
                return;
            }
            _audioPlayer.PlayEffect(audioTrackCollection.AudioTracks[Random.Range(0,
                audioTrackCollection.AudioTracks.Length)]);
        }
    }

}