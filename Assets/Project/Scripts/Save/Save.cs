using System;
using UnityEngine;

namespace Project.Save
{
    [Serializable]
    public class Save
    {
        public SaveData saveData;

        public Save()
        {
            CreateNew();
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    
        public void LoadFromJson(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
        
        private void CreateNew()
        {
            saveData = new SaveData();
        }
    }
}