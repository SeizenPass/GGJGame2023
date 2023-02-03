using UnityEngine;

namespace Project.Dialogue
{
    public class DialogueProxy
    {
        private bool _pendingDialogue;

        public bool PendingDialogue => _pendingDialogue;

        private DialogueCollection _currentDialogueCollection;

        public DialogueCollection CurrentDialogueCollection => _currentDialogueCollection;

        public void SetDialogueCollection(DialogueCollection collection)
        {
            _currentDialogueCollection = collection;
            _pendingDialogue = true;
        }
    }
}