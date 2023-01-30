using Project.Audio;
using UnityEngine;
using Zenject;

namespace Project.Infrastructure
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioPlayer audioPlayer;
        public override void InstallBindings()
        {
            Container.Bind<AudioPlayer>().FromInstance(audioPlayer).AsSingle().NonLazy();
        }
    }
}