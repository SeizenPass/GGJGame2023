using System.Collections.Generic;
using Project.Dialogue;
using Project.Levels;
using Project.Save;
using Project.SceneManagement;
using UnityEngine;
using Zenject;

namespace Project.Core
{
    public class GameLoader : MonoBehaviour
    {
        [Inject] private SaveManager _saveManager;
        [Inject] private DialogueProxy _dialogueProxy;
        [Inject] private SceneLoader _sceneLoader;
        

        [SerializeField] private SceneUnit levelSelectorScene, dialogueScene;
        [SerializeField] private DialogueCollection introductionDialogue;
        [SerializeField] private LevelUnit defaultLevel;
        
        
        
        public void Play()
        {
            var save = _saveManager.Save;
            if (save.IntroductionCompleted)
            {
                _sceneLoader.RequestLoadScene(levelSelectorScene.SceneName);
            }
            else
            {
                save.IntroductionCompleted = true;
                if (save.OpenLevels == null) save.OpenLevels = new List<string>();
                save.OpenLevels.Add(defaultLevel.CodeName);
                _saveManager.UpdateSaveData(save, true);
                _dialogueProxy.SetDialogueCollection(introductionDialogue);
                _sceneLoader.RequestLoadScene(dialogueScene.SceneName);
            }
        }
    }
}