using UnityEngine;
using Zenject;

public class ProjectileWeapon : BaseWeapon
{
    [Header("Weapon Data")]
    [SerializeField]
    private ProjectileWeaponDataSheet _weaponDataSheet;

    private bool _isAiming;
    private int _currentAmmo;

    private SettingsHolder _settings;

    [Inject]
    public void Construct(SettingsHolder settings)
    {
        _settings = settings;
    }

    public override void PrimaryFunction()
    {
        
    }

    public override void SecondaryFunction() 
    {

    }

    public void RefillAmmo()
    {
        _currentAmmo = _weaponDataSheet.MaxAmmo;
    }
}
