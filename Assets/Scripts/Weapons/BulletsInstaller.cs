using UnityEngine;
using Zenject;

public class BulletsInstaller : MonoInstaller
{
    [SerializeField]
    private Bullet _bulletPrefab;
    [SerializeField]
    private int _poolSize = 100;

    // BindMemoryPool tells Zenject "I want a pool of Bullets". //
    // The second generic type (Bullet.Pool) is just a nested helper class Zenject generates, which represents the pool itself. //
    // FromCompononentInNewPrefab tells Zenjects its specifically the Bullet component it needs to work with. //
    // UnderTransformGroup is just the parent Transform all the bullets will be created under. //
    public override void InstallBindings()
    {
        Container.BindMemoryPool<Bullet, Bullet.Pool>()
            .WithInitialSize(_poolSize)
            .FromComponentInNewPrefab(_bulletPrefab)
            .UnderTransformGroup("BulletsPool");
    }
}
