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
            _sceneLoader.RequestLoadScene(sceneUnit.SceneName);
        }
    }
}