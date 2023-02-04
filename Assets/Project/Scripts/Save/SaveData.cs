using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Save
{
    [Serializable]
    public struct SaveData
    {
        [SerializeField] private List<string> openLevels;
        [SerializeField] private List<string> completedLevels;
        [SerializeField] private bool introductionCompleted;

        public List<string> OpenLevels
        {
            get => openLevels;
            set => openLevels = value;
        }

        public List<string> CompletedLevels
        {
            get => completedLevels;
            set => completedLevels = value;
        }

        public bool IntroductionCompleted
        {
            get => introductionCompleted;
            set => introductionCompleted = value;
        }
    }
}