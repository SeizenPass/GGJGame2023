using Project.Dialogue;
using Project.SceneManagement;
using UnityEngine;
using Zenject;

namespace Project.Levels
{
    public class LevelWinHandler : MonoBehaviour
    {
        [SerializeField] private SceneUnit dialogueScene, levelSelectorScene;
        
        
        [Inject] private LevelManager _levelManager;
        [Inject] private DialogueProxy _dialogueProxy;
        [Inject] private SceneLoader _sceneLoader;
        
        public void WinHandle()
        {
            var level = _levelManager.CurrentLevel;
            _dialogueProxy.SetDialogueCollection(level.AfterDialogue);
            
            _levelManager.FinishLevel();
            
            if (_dialogueProxy.PendingDialogue)
            {
                _sceneLoader.RequestLoadScene(dialogueScene.SceneName);
            }
            else
            {
                _sceneLoader.RequestLoadScene(levelSelectorScene.SceneName);
            }
        }
    }
}