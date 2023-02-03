using UnityEngine;
using Zenject;

namespace Project.SceneManagement
{
    public class SceneLoaderCommunicator : MonoBehaviour
    {
        [Inject]
        private SceneLoader _sceneLoader;

        public void RequestSceneLoad(SceneUnit sceneUnit)
        {
            Debug.Log(_sceneLoader);
            _sceneLoader.RequestLoadScene(sceneUnit.SceneName);
        }
    }
}