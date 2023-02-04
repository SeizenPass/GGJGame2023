using UnityEngine;
using UnityEngine.Events;

namespace Project.Utils
{
    public class ClickNotifier : MonoBehaviour
    {
        public UnityEvent onClicked;
        private void OnMouseDown()
        {
            onClicked.Invoke();
        }
    }
}