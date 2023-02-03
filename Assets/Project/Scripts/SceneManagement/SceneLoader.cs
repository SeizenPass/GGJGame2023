using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.SceneManagement
{
    public class SceneLoader
    {
        private bool _loadInProgress;
        
        public Action<string> SceneLoadCompleted;
        public Action SceneLoadStarted;
        
        public void RequestLoadScene(string name, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            if (_loadInProgress) Debug.LogWarning("Scene loading in progress... Request denied.");
            SceneLoadStarted?.Invoke();
            SceneManager.LoadSceneAsync(name, loadSceneMode).completed +=
                _ => SceneLoadCompleted?.Invoke(name);
        }
    }
}