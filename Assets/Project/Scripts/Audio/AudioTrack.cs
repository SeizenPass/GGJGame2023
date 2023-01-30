using Project.Core;
using UnityEngine;

namespace Project.Audio
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(Audio) +
                                Constants.Slash + nameof(AudioTrack))]
    public class AudioTrack : ScriptableObject
    {
        [SerializeField] private AudioClip audioClip;
        public AudioClip AudioClip => audioClip;
    }
}