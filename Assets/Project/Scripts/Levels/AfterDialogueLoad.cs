using UnityEngine;
using Zenject;

namespace Project.Levels
{
    public class AfterDialogueLoad : MonoBehaviour
    {
        [Inject] private LevelManager _levelManager;

        public void CallbackDialogueEnd()
        {
            _levelManager.PlayCurrentLevel();
        }
    }
}