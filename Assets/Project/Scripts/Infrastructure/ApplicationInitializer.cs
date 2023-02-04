using System;
using Cysharp.Threading.Tasks;
using Project.Levels;
using Project.SceneManagement;
using UnityEngine;
using Zenject;

namespace Project.Infrastructure
{
    public class ApplicationInitializer : MonoBehaviour
    {
        [SerializeField] private SceneLoaderCommunicator sceneLoaderCommunicator;
        [SerializeField] private SceneUnit targetScene;
        
        
        [Inject] private LevelManager _levelManager;
        private async void Start()
        {
            await UniTask.WaitUntil(() => _levelManager.Ready);
            
            DoTheThing();
        }

        private void DoTheThing()
        {
            sceneLoaderCommunicator.RequestSceneLoad(targetScene);
        }
    }
}