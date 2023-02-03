using UnityEngine;

namespace Project.Save
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private string saveFilename = "game.save";
        [SerializeField] private string backupSaveFilename = "game.save.bak";
        private Save _save;

        public SaveData Save => _save.saveData;
        public bool SaveLoadedFromDisk { get; private set; }

        private void Awake()
        {
            _save = new Save();
            if (!LoadSaveDataFromDisk())
            {
                Debug.Log("Writing new save file.");
                WriteEmptySaveFile();
            }

            SaveLoadedFromDisk = true;
        }

        private bool LoadSaveDataFromDisk()
        {
            if (FileManager.LoadFromFile(saveFilename, out var json))
            {
                _save.LoadFromJson(json);
                return true;
            }
            
            return false;
        }

        public void UpdateSaveData(SaveData saveData, bool persistAfterUpdate = false)
        {
            _save.saveData = saveData;
            if (persistAfterUpdate) SaveDataToDisk();
        }

        public void SaveDataToDisk()
        {
            if (FileManager.MoveFile(saveFilename, backupSaveFilename))
            {
                if (FileManager.WriteToFile(saveFilename, _save.ToJson()))
                {
                    Debug.Log("Save successful");
                }
            }
        }

        private void WriteEmptySaveFile()
        {
            FileManager.WriteToFile(saveFilename, "");
        }

    }
}