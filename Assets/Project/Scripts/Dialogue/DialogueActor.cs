using Project.Core;
using UnityEngine;

namespace Project.Dialogue
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(Dialogue) +
                                Constants.Slash + nameof(DialogueActor))]
    public class DialogueActor : ScriptableObject
    {
        [SerializeField] private string displayName;

        public string DisplayName => displayName;
    }
}