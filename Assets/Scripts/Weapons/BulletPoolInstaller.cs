using UnityEngine;
using Zenject;

public class BulletPoolInstaller : MonoInstaller
{
    [SerializeField]
    private BulletPool _bulletPool;

    public override void InstallBindings()
    {
        Container.Bind<BulletPool>().FromInstance(_bulletPool).NonLazy();
    }
}
