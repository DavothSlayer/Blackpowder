using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Weapon Data Sheet", menuName = "Data Sheets/Create Projectile Weapon Data Sheet")]
public class BulletWeaponDataSheet : BaseWeaponDataSheet
{
    [Header("Weapon Features")]
    [SerializeField]
    private float _roundsPerSecondFromHip;
    [SerializeField]
    private float _roundsPerSecondAimed;
    [SerializeField]
    private int _maxAmmo;
    [SerializeField]
    private int _projectilesPerShot;

    [Header("Ballistics")]
    [SerializeField]
    private float _projectileSpeed;
    [SerializeField]
    private float _projectileRange;
    [SerializeField]
    private float _projectileSpreadX;
    [SerializeField]
    private float _projectileSpreadY;

    // This effectively sets the values as read only, but available from other classes. //
    public float RoundsPerSecondFromHip => _roundsPerSecondFromHip;
    public float RoundsPerSecondAimed => _roundsPerSecondAimed;
    public int MaxAmmo => _maxAmmo;
    public int ProjectilesPerShot => _projectilesPerShot;

    public float ProjectileSpeed => _projectileSpeed;
    public float ProjectileRange => _projectileRange;
    public float ProjectileSpreadX => _projectileSpreadX;
    public float ProjectileSpreadY => _projectileSpreadY;
}
