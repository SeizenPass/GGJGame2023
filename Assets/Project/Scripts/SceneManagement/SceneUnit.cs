using Project.Core;
using UnityEngine;

namespace Project.SceneManagement
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(SceneManagement) +
                                Constants.Slash + nameof(SceneUnit))]
    public class SceneUnit : ScriptableObject
    {
        [SerializeField] private string sceneName;

        public string SceneName => sceneName;
    }
}