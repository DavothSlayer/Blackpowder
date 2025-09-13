using UnityEngine;
using Zenject;

public class BulletWeapon : BaseWeapon
{
    [Header("Weapon Data")]
    [SerializeField]
    private BulletWeaponDataSheet _weaponDataSheet;

    [SerializeField]
    private Transform _bulletSpawnPoint;

    private bool _isAiming;
    private int _currentAmmo;

    // Zenject dependency injection. //
    private Bullet.Pool _bulletsPool;

    [Inject]
    public void Construct(Bullet.Pool pool)
    {
        _bulletsPool = pool;
    }

    public override void PrimaryFunction()
    {
        for(int i = 0; i < _weaponDataSheet.ProjectilesPerShot; i++)
        {
            Ray _bulletRay = new(_bulletSpawnPoint.position, _bulletSpawnPoint.forward);
            RaycastHit _bulletHit = new RaycastHit();

            Bullet _bullet = _bulletsPool.Spawn();

            // If it hits something, use the hit position. Else, use a dummy position if the player shoots in the sky for example. //
            if (Physics.Raycast(_bulletRay, out _bulletHit, _weaponDataSheet.ProjectileRange))
            {
                _bullet.MoveTowardsTargetPos(_bulletSpawnPoint.position, _bulletSpawnPoint.forward, _bulletHit.point);
            }
            else
            {
                Vector3 _dummyPos = _bulletSpawnPoint.forward * _weaponDataSheet.ProjectileRange;

                _bullet.MoveTowardsTargetPos(_bulletSpawnPoint.position, _bulletSpawnPoint.forward, _dummyPos);
            }
        }
    }

    public override void SecondaryFunction() 
    {

    }

    public void RefillAmmo()
    {
        _currentAmmo = _weaponDataSheet.MaxAmmo;
    }
}
