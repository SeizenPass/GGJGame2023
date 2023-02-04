using Project.Dialogue;
using Project.Levels;
using Project.Save;
using Project.SceneManagement;
using UnityEngine;
using Zenject;

namespace Project.Infrastructure
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private SaveManager saveManager;
        [SerializeField] private LevelManager levelManager;
        
        
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle().NonLazy();
            Container.Bind<DialogueProxy>().AsSingle().NonLazy();
            Container.Bind<SaveManager>().FromInstance(saveManager).AsSingle().NonLazy();
            Container.Bind<LevelManager>().FromInstance(levelManager).AsSingle().NonLazy();
        }
    }
}