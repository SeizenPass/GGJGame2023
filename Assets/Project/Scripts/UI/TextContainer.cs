using TMPro;
using UnityEngine;

namespace Project.UI
{
    public class TextContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public TextMeshProUGUI Text
        {
            get => text;
            set => text = value;
        }
    }
}