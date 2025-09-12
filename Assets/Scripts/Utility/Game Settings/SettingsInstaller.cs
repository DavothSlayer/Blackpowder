using Zenject;

public class SettingsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SettingsHolder>().AsSingle().NonLazy();
    }
}
