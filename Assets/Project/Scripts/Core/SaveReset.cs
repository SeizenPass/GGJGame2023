using System.Collections.Generic;
using Project.Save;
using UnityEngine;
using Zenject;

namespace Project.Core
{
    public class SaveReset : MonoBehaviour
    {
        [Inject] private SaveManager _saveManager;
        public void ResetData()
        {
            var save = _saveManager.Save;
            save.CompletedLevels = new List<string>();
            save.IntroductionCompleted = false;
            save.OpenLevels = new List<string>();
            _saveManager.UpdateSaveData(save, true);
        }
    }
}