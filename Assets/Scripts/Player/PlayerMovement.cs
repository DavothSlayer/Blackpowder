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

    private Vector3 _moveVector, _jumpVector, _gravityVector, _smoothMoveVector, _refVector;
    private float _currentPlayerSpeed;
    private void MovementLogic()
    {
        if (_characterController.isGrounded)
        {
            _moveVector = Vector3.zero;

            if (Input.GetKey(_settings.Data.ForwardKey)) _moveVector += transform.forward;
            if (Input.GetKey(_settings.Data.StrafeLeftKey)) _moveVector -= transform.right;
            if (Input.GetKey(_settings.Data.BackwardKey)) _moveVector -= transform.forward;
            if (Input.GetKey(_settings.Data.StrafeRightKey)) _moveVector += transform.right;

            // Chooses player speed based on Shift key input. //
            _currentPlayerSpeed = Input.GetKey(_settings.Data.RunKey) ? _playerData.RunSpeed : _playerData.WalkSpeed;
        }

        // Makes sure the vector magnitude is never greater than 1f. //
        _moveVector.Normalize();

        _smoothMoveVector = Vector3.SmoothDamp(_smoothMoveVector, _moveVector, ref _refVector, _playerData.MovementSmoothingTime);

        _characterController.Move(_smoothMoveVector * _currentPlayerSpeed * Time.deltaTime);

        _gravityVector.z = Mathf.Clamp(_gravityVector.z, 0f, _playerData.RunJumpSpeedBoost);

        // Gravity logic. Keeps the character grounded even if not midair. //
        if (!_characterController.isGrounded)
        {
            _gravityVector.y += _playerData.Gravity * Time.deltaTime;
            _gravityVector.z += _playerData.Gravity * Time.deltaTime;
        }
        else if(_gravityVector.y < 0f)
        {
            _gravityVector.y = -2f;
        }

            _characterController.Move(transform.TransformDirection(_gravityVector) * Time.deltaTime);

        // Jump logic. //
        if (_characterController.isGrounded && Input.GetKeyDown(_settings.Data.JumpKey)) Jump();
    }

    private void Jump()
    {
        _gravityVector.y = Mathf.Sqrt(2f * -_playerData.Gravity * _playerData.JumpHeight);

        if(_currentPlayerSpeed == _playerData.RunSpeed) _gravityVector.z = _playerData.RunJumpSpeedBoost;
    }

    private void Crouch()
    {

    }

    private void Slide()
    {

    }
}
