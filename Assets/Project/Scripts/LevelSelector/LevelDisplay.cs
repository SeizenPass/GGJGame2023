using System;
using Cysharp.Threading.Tasks;
using Project.Levels;
using Project.Utils;
using UnityEngine;
using Zenject;

namespace Project.LevelSelector
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private LevelUnit targetLevel;
        [SerializeField] private ClickNotifier _clickNotifier;

        [Inject] private LevelManager _levelManager;

        private async void Start()
        {
            await UniTask.WaitUntil(() => _levelManager.Ready);
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
            _levelManager.RequestLevelLoad(targetLevel);
        }
    }
}