using UnityEngine;
using UnityEngine.UI;

namespace Project.Dialogue.UI
{
    public class DialogueAvatarUI : MonoBehaviour
    {
        [SerializeField] private Image avatarContainer;
        [SerializeField] private GameObject avatarBoxObject;

        public Image AvatarContainer
        {
            get => avatarContainer;
            set => avatarContainer = value;
        }

        public GameObject AvatarBoxObject
        {
            get => avatarBoxObject;
            set => avatarBoxObject = value;
        }
    }
}