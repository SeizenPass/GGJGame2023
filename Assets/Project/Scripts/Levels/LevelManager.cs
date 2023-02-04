using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.Dialogue;
using Project.Save;
using Project.SceneManagement;
using Project.Utils;
using UnityEngine;
using Zenject;

namespace Project.Levels
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private SceneUnit dialogSceneUnit, levelSelectorScene;

        private SaveManager _saveManager;
        private SceneLoader _sceneLoader;
        private DialogueProxy _dialogueProxy;

        [Inject]
        private void Construct(SaveManager saveManager, SceneLoader sceneLoader, DialogueProxy dialogueProxy)
        {
            _saveManager = saveManager;
            _sceneLoader = sceneLoader;
            _dialogueProxy = dialogueProxy;
        }

        private LevelUnit _currentLevel;

        public bool Ready { get; private set; }
        private async void Awake()
        {
            await UniTask.WaitUntil(() => _saveManager.SaveLoadedFromDisk);
            Ready = true;
        }

        public void RequestLevelLoad(LevelUnit levelUnit)
        {
            //TODO: check if it is open
            _dialogueProxy.SetDialogueCollection(levelUnit.RequiredDialogue);
            _currentLevel = levelUnit;
            if (_dialogueProxy.PendingDialogue)
            {
                _sceneLoader.RequestLoadScene(dialogSceneUnit.SceneName);
            }
            else
            {
                PlayCurrentLevel();
            }
        }

        public void PlayCurrentLevel()
        {
            if (!_currentLevel)
            {
                Debug.LogWarning("No current level.");
                _sceneLoader.RequestLoadScene(levelSelectorScene.SceneName);
                return;
            }
            _sceneLoader.RequestLoadScene(_currentLevel.TargetSceneUnit.SceneName);
        }

        public void FinishLevel()
        {
            var save = _saveManager.Save;
            if (save.CompletedLevels == null)
            {
                save.CompletedLevels = new List<string>();
            }
            if (!ListUtils.Contains(save.CompletedLevels, _currentLevel.CodeName))
            {
                save.CompletedLevels.Add(_currentLevel.CodeName);
            }

            if (save.OpenLevels == null) save.OpenLevels = new List<string>();
            foreach (var op in _currentLevel.OpeningLevels)
            {
                if (!ListUtils.Contains(save.OpenLevels, op.CodeName))
                {
                    save.OpenLevels.Add(op.CodeName);
                }
            }
            
            _saveManager.UpdateSaveData(save, true);
            
            _currentLevel = null;
        }

        public LevelUnit CurrentLevel => _currentLevel;
    }
}