using Project.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Dialogue
{
    [CreateAssetMenu(menuName = Constants.ScriptableObjectPrefix + nameof(Dialogue) +
                                Constants.Slash + nameof(DialogueAvatar))]
    public class DialogueAvatar : ScriptableObject
    {
        [SerializeField] private Sprite avatarSprite;
        [SerializeField] private bool facingRight;
        
        public Sprite AvatarSprite => avatarSprite;

        public bool FacingRight => facingRight;
    }
}