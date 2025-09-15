using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInventory : MonoBehaviour
{
    private BaseWeapon _primaryWeapon;
    private BaseWeapon _secondaryWeapon;
    private List<BaseWeapon> _meleeWeapons;
    private List<BaseWeapon> _throwables;

    private SettingsHolder _settings;

    [Inject]
    public void Construct(SettingsHolder settings)
    {
        _settings = settings;
    }

    public void SetPrimaryWeapon(BaseWeapon weapon)
    {
        _primaryWeapon = weapon;
    }

    public void SetSecondaryWeapon(BaseWeapon weapon)
    {
        _secondaryWeapon = weapon;
    }

    public void SetMeleeWeapon(BaseWeapon weapon)
    {
        // What the fuck??
    }
}
