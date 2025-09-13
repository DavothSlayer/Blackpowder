using UnityEngine;
using Zenject;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private Camera _playerCam;

    private SettingsHolder _settings;

    [Inject]
    public void Construct(SettingsHolder settings)
    {
        _settings = settings;
    }

    // Lock the cursor and hide it. //
    private void Awake() => Cursor.lockState = CursorLockMode.Locked;

    private void Update()
    {
        CameraLogic();
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
}
