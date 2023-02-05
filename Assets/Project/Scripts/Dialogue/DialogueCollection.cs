using System.Collections.Generic;
using Project.Audio;
using Project.Core;
using UnityEngine;

namespace Project.Dialogue
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(Dialogue) +
                                Constants.Slash + nameof(DialogueCollection))]
    public class DialogueCollection : ScriptableObject
    {
        [SerializeField] private AudioTrack audioTrack;
        
        [SerializeField] private List<DialogueUnit> dialogues;

        public List<DialogueUnit> Dialogues => dialogues;

        public AudioTrack AudioTrack => audioTrack;
    }
}