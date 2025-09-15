using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [Header("Weapon Data")]
    [SerializeField]
    private BaseWeaponDataSheet _weaponData;

    public BaseWeaponDataSheet WeaponData => _weaponData;

    // For things like shooting a weapon, or swinging an axe. //
    public virtual void PrimaryFunction()
    {

    }

    // For things like aiming a weapon, or perhaps throwing an axe. //
    public virtual void SecondaryFunction()
    {

    }
}
