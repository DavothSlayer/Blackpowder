using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Transform _weaponHolder;

    private BaseWeapon _unarmed;
    private BaseWeapon _primaryWeapon;
    private BaseWeapon _secondaryWeapon;
    private List<BaseWeapon> _meleeWeapons = new List<BaseWeapon>();
    private List<BaseWeapon> _throwables = new List<BaseWeapon>();

    private PlayerDataSheet _playerData;

    public BaseWeapon Unarmed => _unarmed;
    public BaseWeapon PrimaryWeapon => _primaryWeapon;
    public BaseWeapon SecondaryWeapon => _secondaryWeapon;
    public List<BaseWeapon> MeleeWeapons => _meleeWeapons;
    public List<BaseWeapon> Throwables => _throwables;

    private void Awake() => Initialize();

    private void Initialize()
    {
        // Set the maximum capacity of these two list according to the player data sheet. //
        MeleeWeapons.Capacity = _playerData.MaxMeleeWeapons;
        Throwables.Capacity = _playerData.MaxThrowables;

        // Go through the Weaponholder transform's children to find out what weapons are //
        // already in the inventory. //
        for(int i = 0; i < _weaponHolder.childCount; i++)
        {
            // Setup an index. We know for sure that there can be only weapons in these objects. //
            WeaponType _indexType = _weaponHolder.GetChild(i).GetComponent<BaseWeapon>().WeaponData.WeaponType;

            if (_indexType == WeaponType.Primary) _primaryWeapon = _weaponHolder.GetChild(i).GetComponent<BaseWeapon>();
            if (_indexType == WeaponType.Secondary) _secondaryWeapon = _weaponHolder.GetChild(i).GetComponent<BaseWeapon>();
            
            // Since these two WeaponTypes can be carried in different amounts, they will have to be //
            // assigned in a different way. //
            // if (_index.WeaponData.WeaponType == WeaponType.Melee) _primaryWeapon = _index;
            // if (_index.WeaponData.WeaponType == WeaponType.Primary) _primaryWeapon = _index;
        }
    }

    [Inject]
    public void Construct(PlayerDataSheet playerDataSheet)
    {
        _playerData = playerDataSheet;
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
        // What the fuck?? //
    }

    public void SetThrowableWeapon(BaseWeapon weapon)
    {
        // Again, what the fuck is wrong with you? //
    }
}
