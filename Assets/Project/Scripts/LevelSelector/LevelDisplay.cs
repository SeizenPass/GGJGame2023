using System;
using Cysharp.Threading.Tasks;
using Microsoft.Unity.VisualStudio.Editor;
using Project.Levels;
using Project.Save;
using Project.Utils;
using UnityEngine;
using Zenject;
using Image = UnityEngine.UI.Image;

namespace Project.LevelSelector
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private LevelUnit targetLevel;
        [SerializeField] private ClickNotifier _clickNotifier;
        [SerializeField] private Color disabledColor, completedColor;
        [SerializeField] private SpriteRenderer targetImage;
        [SerializeField] private bool forceAvailability;
        

        [Inject] private LevelManager _levelManager;
        [Inject] private SaveManager _saveManager;

        private bool _available;

        private async void Start()
        {
            await UniTask.WaitUntil(() => _levelManager.Ready);

            if (!forceAvailability && !GetAvailability())
            {
                targetImage.color = disabledColor;
            }
            else _available = true;
            if (IsCompleted())
            {
                targetImage.color = completedColor;
            }
        }

        private bool GetAvailability()
        {
            var save = _saveManager.Save;
            if (save.OpenLevels == null) return false;
            return ListUtils.Contains(save.OpenLevels, targetLevel.CodeName);
        }

        private bool IsCompleted()
        {
            var save = _saveManager.Save;
            if (save.CompletedLevels == null) return false;
            return ListUtils.Contains(save.CompletedLevels, targetLevel.CodeName);
        }

        private void OnEnable()
        {
            _clickNotifier.onClicked.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _clickNotifier.onClicked.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (!_available) return;
            _levelManager.RequestLevelLoad(targetLevel);
        }
    }
}