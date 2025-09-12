using UnityEngine;

[CreateAssetMenu(fileName = "Player Data Sheet", menuName = "Create Player Data Sheet")]
public class PlayerDataSheet : ScriptableObject
{
    [SerializeField]
    private float _playerWalkSpeed;
    [SerializeField]
    private float _playerRunSpeed;

    // Doing this has a lot more code, but more future proof with more control. //
    public float PlayerWalkSpeed => _playerWalkSpeed;
    public float PlayerRunSpeed => _playerRunSpeed;
}
