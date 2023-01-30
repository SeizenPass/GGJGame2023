using Project.Core;
using UnityEngine;

namespace Project.Audio
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(Audio) +
                                Constants.Slash + nameof(AudioTrackCollection))]
    public class AudioTrackCollection : ScriptableObject
    {
        [SerializeField] private AudioTrack[] audioTracks;

        public AudioTrack[] AudioTracks => audioTracks;
    }
}