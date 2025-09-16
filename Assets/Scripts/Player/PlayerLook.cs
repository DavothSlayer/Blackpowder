using UnityEngine;
using Zenject;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCam;

    // Zenject dependency injection. //
    private SettingsHolder _settings;    
    private PlayerDataSheet _playerDataSheet;

    [Inject]
    public void Construct(SettingsHolder settings, PlayerDataSheet playerDataSheet)
    {
        _settings = settings;
        _playerDataSheet = playerDataSheet;
    }

    // Lock the cursor and hide it. //
    private void Awake() => Initialize();

    private void Update()
    {
        CameraLogic();
        Cinematics();
    }

    private void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _targetFOV = _playerDataSheet.WalkingCameraFOV;
    }

    private float _camLookX;
    private float _camLookY;
    private void CameraLogic()
    {
        // Limit the up and down axis to -90 & 90 degrees. //
        _camLookX = Mathf.Clamp(_camLookX, -90f, 90f);

        // Cam Look X is actually Mouse Y, and Cam Look Y is actually Mouse X. Pretty silly right? //
        _camLookX -= Input.GetAxis("Mouse Y") * _settings.Data.MouseSensitivity * Time.deltaTime;
        _camLookY = Input.GetAxis("Mouse X") * _settings.Data.MouseSensitivity * Time.deltaTime;

        // Rotate only the camera locally with _camLookX, and the whole player with _camLookY. //
        _playerCam.transform.localRotation = Quaternion.Euler(_camLookX, 0f, 0f);
        transform.Rotate(transform.up * _camLookY);
    }

    private float _targetFOV;
    private void Cinematics()
    {
        // Some kind of smooth transition between the FOVs would be necessary. Right now, fucking horrible. -Davoth //
        _targetFOV = Input.GetKey(_settings.Data.RunKey) ?
            Mathf.MoveTowards(_targetFOV, _playerDataSheet.RunningCameraFOV, 15f * Time.deltaTime) :
            Mathf.MoveTowards(_targetFOV, _playerDataSheet.WalkingCameraFOV, 15f * Time.deltaTime);

        _playerCam.fieldOfView = _targetFOV;
    }
}
