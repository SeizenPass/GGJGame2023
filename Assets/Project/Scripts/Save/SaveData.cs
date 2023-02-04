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
    }
}