using UnityEngine;
using Zenject;

public class BulletWeapon : BaseWeapon
{
    [SerializeField]
    private Transform _bulletSpawnPoint;

    private BulletWeaponDataSheet _dataSheet => (BulletWeaponDataSheet)WeaponData;

    private bool _isAiming;
    private int _currentAmmo;

    // Zenject dependency injection. -Davoth //
    private Bullet.Pool _bulletsPool;

    [Inject]
    public void Construct(Bullet.Pool pool)
    {
        _bulletsPool = pool;
    }

    public override void PrimaryFunction()
    {
        print("Pew!");

        for(int i = 0; i < _dataSheet.ProjectilesPerShot; i++)
        {
            Ray _bulletRay = new(_bulletSpawnPoint.position, _bulletSpawnPoint.forward);
            RaycastHit _bulletHit = new RaycastHit();

            var _bullet = _bulletsPool.Spawn();

            // If it hits something, use the hit position. Else, use a dummy position if the player shoots in the sky for example. -Davoth //
            if (Physics.Raycast(_bulletRay, out _bulletHit, _dataSheet.ProjectileRange))
            {
                _bullet.Initialize(_bulletSpawnPoint.position, _bulletSpawnPoint.forward, _bulletHit.point, _dataSheet);
            }
            else
            {
                Vector3 _dummyPos = _bulletSpawnPoint.position + _bulletSpawnPoint.forward * _dataSheet.ProjectileRange;

                _bullet.Initialize(_bulletSpawnPoint.position, _bulletSpawnPoint.forward, _dummyPos, _dataSheet);
            }
        }
    }

    public override void SecondaryFunction() 
    {
        print("The other pew!");
    }

    public void RefillAmmo()
    {
        _currentAmmo = _dataSheet.MaxAmmo;
    }
}
