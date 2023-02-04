using System;
using Project.Utils;
using UnityEngine;

namespace Project.LevelSelector
{
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private ClickNotifier _clickNotifier;

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
            Debug.Log("Click");
        }
    }
}