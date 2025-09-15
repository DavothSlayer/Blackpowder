using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class BaseWeaponDataSheet : ScriptableObject
{
    [Header("Base Weapon Data")]
    [SerializeField]
    private string _weaponName;
    [SerializeField]
    private WeaponType _weaponType;
    [SerializeField]
    private GameObject _weaponPrefab;

    public string WeaponName => _weaponName;
    public WeaponType WeaponType => _weaponType;
    public GameObject WeaponPrefab => _weaponPrefab;
}

public enum WeaponType
{
    Primary, Secondary, Melee, Throwable
}
