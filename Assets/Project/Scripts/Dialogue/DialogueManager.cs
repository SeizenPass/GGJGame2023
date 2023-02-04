using System;
using System.Collections;
using Project.Dialogue.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using TextContainer = Project.UI.TextContainer;

namespace Project.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [Inject] private DialogueProxy _dialogueProxy;
        
        [Header("Dependencies")] 
        [SerializeField]
        private TextMeshProUGUI textBox;
        [SerializeField] 
        private DialogueSideBindings left, right;
        [SerializeField] 
        private GameObject nextButton;
        

        [Header("Settings")] 
        [SerializeField]
        private float dialogueSpeed = 1f;

        [Header("Events")] 
        [SerializeField] private UnityEvent onDialogFinished;
        [SerializeField] private UnityEvent onDialogRoutineFinished;
        
        private Coroutine _dialogRoutine;

        private DialogueCollection _currentDialogueCollection;
        private int _currentIndex;
        private void Start()
        {
            _currentDialogueCollection = _dialogueProxy.CurrentDialogueCollection;
            if (!_currentDialogueCollection) Debug.LogWarning("No dialogue!");
            PlayNextLine();
        }

        public void PlayNextLine()
        {
            if (_currentIndex >= _currentDialogueCollection.Dialogues.Count)
            {
                Debug.Log("Dialogue is over.");
                _dialogueProxy.FinishDialogue();
                onDialogFinished.Invoke();
                return;
            }

            if (_dialogRoutine != null)
            {
                StopCoroutine(_dialogRoutine);
                _dialogRoutine = null;
            }
            DisableContent();
            var dialog = _currentDialogueCollection.Dialogues[_currentIndex];
            var side = dialog.AvatarPosition == DialogueAvatarPosition.Left ? left : right;
            side.NameContainer.gameObject.SetActive(true);
            side.NameContainer.Text.text = dialog.Actor.DisplayName;
            side.AvatarUI.AvatarBoxObject.SetActive(true);
            side.AvatarUI.AvatarContainer.sprite = dialog.Avatar.AvatarSprite;
            textBox.text = "";

            StartCoroutine(DialogProcess(dialog.Text));

            _currentIndex++;
        }

        private IEnumerator DialogProcess(string text)
        {
            var symbolCounter = 0;

            while (symbolCounter < text.Length)
            {
                textBox.text += text[symbolCounter];
                yield return new WaitForSeconds(1f / dialogueSpeed);
                
                symbolCounter++;
            }

            _dialogRoutine = null;
            nextButton.SetActive(true);
            onDialogRoutineFinished.Invoke();
        }

        private void DisableContent()
        {
            left.NameContainer.gameObject.SetActive(false);
            right.NameContainer.gameObject.SetActive(false);
            
            left.AvatarUI.AvatarBoxObject.SetActive(false);
            right.AvatarUI.AvatarBoxObject.SetActive(false);
            
            nextButton.SetActive(false);
        }
    }

    [Serializable]
    internal struct DialogueSideBindings
    {
        [SerializeField] private DialogueAvatarUI avatarUI;
        [SerializeField] private TextContainer nameContainer;

        public DialogueAvatarUI AvatarUI => avatarUI;

        public TextContainer NameContainer => nameContainer;
    }
}