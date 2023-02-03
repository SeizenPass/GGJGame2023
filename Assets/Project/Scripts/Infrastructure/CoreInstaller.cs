using Project.Dialogue;
using Project.SceneManagement;
using Zenject;

namespace Project.Infrastructure
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle().NonLazy();
            Container.Bind<DialogueProxy>().AsSingle().NonLazy();
        }
    }
}