using System;
using Project.Core;
using UnityEngine;

namespace Project.Dialogue
{
    [Serializable]
    public struct DialogueUnit
    {
        [SerializeField] private DialogueActor actor;
        [SerializeField] private DialogueAvatar avatar;
        [SerializeField, TextArea] private string text;
        [SerializeField] private DialogueAvatarPosition avatarPosition;

        public DialogueActor Actor => actor;

        public DialogueAvatar Avatar => avatar;

        public string Text => text;

        public DialogueAvatarPosition AvatarPosition => avatarPosition;
    }

    public enum DialogueAvatarPosition
    {
        Left, Right
    }
}