using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data Sheet", menuName = "Data Sheets/Create Player Data Sheet")]
public class PlayerDataSheet : CharacterDataSheet
{
    [Header("Cinematics")]
    [SerializeField]
    [Range(60f, 180f)]
    private float _walkingCameraFOV;
    [SerializeField]
    [Range(60f, 180f)]
    private float _runningCameraFOV;

    [Header("Perks")]
    [SerializeField]
    private Perk[] _perks;

    public float WalkingCameraFOV => _walkingCameraFOV;
    public float RunningCameraFOV => _runningCameraFOV;

    public Perk[] Perks => _perks;
}

[Serializable]
public class Perk
{
    [SerializeField]
    private string _perkName;
}
