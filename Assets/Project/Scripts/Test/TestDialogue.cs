using Project.Dialogue;
using Project.SceneManagement;
using UnityEngine;
using Zenject;

namespace Project.Test
{
    public class TestDialogue : MonoBehaviour
    {
        [Inject] private DialogueProxy _dialogueProxy;
        
        [SerializeField] private DialogueCollection testDialogue;
        [SerializeField] private SceneUnit dialogueScene;
        [SerializeField] private SceneLoaderCommunicator sceneLoaderCommunicator;
        
        
        private void Start()
        {
            _dialogueProxy.SetDialogueCollection(testDialogue);
            sceneLoaderCommunicator.RequestSceneLoad(dialogueScene);
        }
    }
}