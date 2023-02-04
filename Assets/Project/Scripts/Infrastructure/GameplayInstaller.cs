using Project.Gameplay;
using Project.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Project.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CameraAnchor cameraAnchor;
        [SerializeField] private PlayerSpawner playerSpawner;
        
        
        public override void InstallBindings()
        {
            Container.Bind<CameraAnchor>().FromInstance(cameraAnchor).AsSingle().NonLazy();
            Container.Bind<PlayerSpawner>().FromInstance(playerSpawner).AsSingle().NonLazy();
        }
    }
}