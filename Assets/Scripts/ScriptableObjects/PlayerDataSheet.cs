using UnityEngine;

[CreateAssetMenu(fileName = "Player Data Sheet", menuName = "Data Sheets/Create Player Data Sheet")]
public class PlayerDataSheet : ScriptableObject
{
    [SerializeField]
    private float _walkSpeed;
    [SerializeField]
    private float _runSpeed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpHeight;

    // Doing this is a lot more code, but more future proof with more control. //
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float Gravity => _gravity;
    public float JumpHeight => _jumpHeight;
}
