using Project.Dialogue;
using Project.Save;
using Project.SceneManagement;
using UnityEngine;
using Zenject;

namespace Project.Infrastructure
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private SaveManager saveManager;
        
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle().NonLazy();
            Container.Bind<DialogueProxy>().AsSingle().NonLazy();
            Container.Bind<SaveManager>().FromInstance(saveManager).AsSingle().NonLazy();
        }
    }
}