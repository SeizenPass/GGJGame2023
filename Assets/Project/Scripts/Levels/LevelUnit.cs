using Project.Core;
using Project.Dialogue;
using Project.SceneManagement;
using UnityEngine;

namespace Project.Levels
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(Levels) +
                                Constants.Slash + nameof(LevelUnit))]
    public class LevelUnit : ScriptableObject
    {
        [SerializeField] private string codeName;
        [SerializeField] private SceneUnit targetSceneUnit;
        [SerializeField] private DialogueCollection requiredDialogue;

        public string CodeName => codeName;

        public SceneUnit TargetSceneUnit => targetSceneUnit;

        public DialogueCollection RequiredDialogue => requiredDialogue;
    }
}