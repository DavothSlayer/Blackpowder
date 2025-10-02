using UnityEngine;
using Zenject;

public class BulletWeapon : BaseWeapon
{
    [SerializeField]
    private Transform _bulletSpawnPoint;
    [SerializeField]
    private LayerMask _raycastLayers;

    private BulletPool _bulletPool;

    private BulletWeaponDataSheet _dataSheet => (BulletWeaponDataSheet)WeaponData;

    private bool _isAiming;
    private int _currentAmmo;

    [Inject]
    public void Construct(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public override void PrimaryFunction()
    {
        print("Pew!");

        for(int i = 0; i < _dataSheet.ProjectilesPerShot; i++)
        {
            Ray bulletRay = new(_bulletSpawnPoint.position, _bulletSpawnPoint.forward);
            RaycastHit bulletHit = new RaycastHit();

            Bullet bullet = _bulletPool.Spawn(_bulletSpawnPoint.position, _bulletSpawnPoint.rotation);

            // If it hits something, use the hit position. Else, use a dummy position if the player shoots in the sky for example. -Davoth //
            if (Physics.Raycast(bulletRay, out bulletHit, _dataSheet.ProjectileRange, _raycastLayers))
            {
                bullet.Fire(bulletHit.point, _dataSheet);
            }
            else
            {
                bullet.Fire(_bulletSpawnPoint.forward * _dataSheet.ProjectileRange, _dataSheet);
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
