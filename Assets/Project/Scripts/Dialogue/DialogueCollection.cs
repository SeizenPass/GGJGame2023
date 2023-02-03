using System.Collections.Generic;
using Project.Core;
using UnityEngine;

namespace Project.Dialogue
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(Dialogue) +
                                Constants.Slash + nameof(DialogueCollection))]
    public class DialogueCollection : ScriptableObject
    {
        [SerializeField] private List<DialogueUnit> dialogues;

        public List<DialogueUnit> Dialogues => dialogues;
    }
}