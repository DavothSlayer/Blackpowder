using UnityEngine;

[CreateAssetMenu(fileName = "Player Data Sheet", menuName = "Data Sheets/Create Player Data Sheet")]
public class PlayerDataSheet : ScriptableObject
{
    [Header("Numerical Values")]
    [SerializeField]
    private float _walkSpeed;
    [SerializeField]
    private float _runSpeed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpHeight;

    [Header("Inventory")]
    [SerializeField]
    private int _maxMeleeWeapons;
    [SerializeField]
    private int _maxThrowables;
    [SerializeField]
    private int _maxMedkits;
    [SerializeField]
    private int _maxPowerups;

    // Doing this is a lot more code, but more future proof with more control. //
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float Gravity => _gravity;
    public float JumpHeight => _jumpHeight;

    public int MaxMeleeWeapons => _maxMeleeWeapons;
    public int MaxThrowables => _maxThrowables;
    public int MaxMedkits => _maxMedkits;
    public int MaxPowerups => _maxPowerups;
}
