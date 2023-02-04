using Project.Gameplay;
using Project.Gameplay.Player;
using Project.Levels;
using Project.UI;
using UnityEngine;
using Zenject;

namespace Project.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CameraAnchor cameraAnchor;
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private HealthUI healthUI;
        [SerializeField] private LevelLogic levelLogic;
        [SerializeField] private PauseBehaviour pauseBehaviour;
        



        public override void InstallBindings()
        {
            Container.Bind<CameraAnchor>().FromInstance(cameraAnchor).AsSingle().NonLazy();
            Container.Bind<PlayerSpawner>().FromInstance(playerSpawner).AsSingle().NonLazy();
            Container.Bind<HealthUI>().FromInstance(healthUI).AsSingle().NonLazy();
            Container.Bind<LevelLogic>().FromInstance(levelLogic).AsSingle().NonLazy();
            Container.Bind<PauseBehaviour>().FromInstance(pauseBehaviour).AsSingle().NonLazy();
        }
    }
}