using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInventory : MonoBehaviour
{
    [SerializeField]
    private Transform _weaponHolder;
    [SerializeField]
    private CharacterDataSheet _charDataSheet;

    private BaseWeapon _unarmed;
    private BaseWeapon _primaryWeapon;
    private BaseWeapon _secondaryWeapon;
    private List<BaseWeapon> _meleeWeapons = new List<BaseWeapon>();
    private List<BaseWeapon> _utilityWeapons = new List<BaseWeapon>();

    public Transform WeaponHolder => _weaponHolder;
    public CharacterDataSheet CharDataSheet => _charDataSheet;

    public BaseWeapon Unarmed => _unarmed;
    public BaseWeapon PrimaryWeapon => _primaryWeapon;
    public BaseWeapon SecondaryWeapon => _secondaryWeapon;
    public List<BaseWeapon> MeleeWeapons => _meleeWeapons;
    public List<BaseWeapon> UtilityWeapons => _utilityWeapons;

    #region Setting Weapons
    public void SetPrimaryWeapon(BaseWeapon newWeapon)
    {
        // This is effectively just a filter to check if it really is a primary weapon. -Davoth //
        if (newWeapon.WeaponData.WeaponType != WeaponType.Primary)
        {
            print("That's not a primary. Moron."); 
            return;
        }
        else 
        {
            _primaryWeapon = newWeapon;
        }
    }

    public void SetSecondaryWeapon(BaseWeapon newWeapon)
    {
        // This is effectively just a filter to check if it really is a secondary weapon. -Davoth //
        if (newWeapon.WeaponData.WeaponType != WeaponType.Secondary)
        {
            print("That's not a secondary. Idiot.");
            return;
        }
        else
        {
            _secondaryWeapon = newWeapon;
        }
    }

    public void SetMeleeWeapon(BaseWeapon newMelee, int currentMeleeIndex)
    {
        // This one is a bit more fucked. Please read carefully. -Davoth //

        // First, the same filter with the previous ones. -Davoth //
        if (newMelee.WeaponData.WeaponType != WeaponType.Melee)
        {
            print("That's not a Melee. Goofball.");
            return;
        }
        else
        {
            // If the melee weapon slots are not full, just add the new melee weapon as is. //
            // If the above is NOT true, then drop the *current* melee of that index and //
            // replace it with the new one. -Davoth //
            if (_meleeWeapons.Count != _charDataSheet.MaxMeleeWeapons)
            {
                _meleeWeapons.Add(newMelee);
            }
            else
            {
                DropMeleeWeapon(_meleeWeapons[currentMeleeIndex]);
                _meleeWeapons.Add(newMelee);
            }
        }
    }

    public void SetUtilityWeapon(BaseWeapon newUtility, int currentUtilityIndex)
    {
        // Complete copy of the SetMeleeWeapon method, but for utility. -Davoth //

        if (newUtility.WeaponData.WeaponType != WeaponType.Utility)
        {
            print("That's not a Utility. Bastard.");
            return;
        }
        else
        {
            if (_utilityWeapons.Count != _charDataSheet.MaxUtilityWeapons)
            {
                _utilityWeapons.Add(newUtility);
            }
            else
            {
                DropUtilityWeapon(_utilityWeapons[currentUtilityIndex]);
                _utilityWeapons.Add(newUtility);
            }
        }
    }
    #endregion

    #region Dropping Weapons
    public void DropPrimaryWeapon(BaseWeapon dropWeapon)
    {

    }

    public void DropSecondaryWeapon(BaseWeapon dropWeapon)
    {

    }
    
    public void DropMeleeWeapon(BaseWeapon dropWeapon)
    {

    }
    
    public void DropUtilityWeapon(BaseWeapon dropWeapon)
    {

    }
    #endregion
}
