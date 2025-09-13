using UnityEngine;

public abstract class BaseWeaponDataSheet : ScriptableObject
{
    [Header("Base Weapon Data")]
    [SerializeField]
    private string _weaponName;
    [SerializeField]
    private GameObject _weaponPrefab;
}
