using System.Collections.Generic;
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
        [SerializeField] private DialogueCollection requiredDialogue, afterDialogue;
        [SerializeField] private List<LevelUnit> openingLevels;
        
        public string CodeName => codeName;

        public SceneUnit TargetSceneUnit => targetSceneUnit;

        public DialogueCollection RequiredDialogue => requiredDialogue;

        public List<LevelUnit> OpeningLevels => openingLevels;

        public DialogueCollection AfterDialogue => afterDialogue;
    }
}