using Project.Gameplay;
using UnityEngine;
using Zenject;

namespace Project.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CameraAnchor cameraAnchor;
        
        public override void InstallBindings()
        {
            Container.Bind<CameraAnchor>().FromInstance(cameraAnchor).AsSingle().NonLazy();
        }
    }
}