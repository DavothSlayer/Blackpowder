using TMPro.EditorUtilities;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;

    // Zenject dependency injection. //
    private PlayerDataSheet _playerData;
    private SettingsHolder _settings;

    [Inject]
    public void Construct(SettingsHolder settings, PlayerDataSheet playerDataSheet)
    {
        _settings = settings;
        _playerData = playerDataSheet;
    }

    private void Update()
    {
        MovementLogic();
    }

    private Vector3 _moveVector, _gravityVector;
    private float _currentPlayerSpeed;
    private void MovementLogic()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(_settings.Data.ForwardKey)) _moveVector += transform.forward;
        if (Input.GetKey(_settings.Data.StrafeLeftKey)) _moveVector -= transform.right;
        if (Input.GetKey(_settings.Data.BackwardKey)) _moveVector -= transform.forward;
        if (Input.GetKey(_settings.Data.StrafeRightKey)) _moveVector += transform.right;

        // Movement logic. Chooses player speed based on Shift key input. //
        _currentPlayerSpeed = Input.GetKey(_settings.Data.RunKey) ? _playerData.RunSpeed : _playerData.WalkSpeed;
        _moveVector.Normalize();
        _characterController.Move(_moveVector * _currentPlayerSpeed * Time.deltaTime);

        // Gravity logic. Keeps the character grounded even if not midair. //
        if (!_characterController.isGrounded) _gravityVector.y += _playerData.Gravity * Time.deltaTime;
        else if (_gravityVector.y < 0f) _gravityVector.y = -2f;
        _characterController.Move(_gravityVector * Time.deltaTime);

        // Jump logic. //
        if(_characterController.isGrounded && Input.GetKeyDown(_settings.Data.JumpKey))
        {
            _gravityVector.y = Mathf.Sqrt(2f * -_playerData.Gravity * _playerData.JumpHeight);
        }
    }
}
