using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private Camera _playerCam;

    private SettingsHolder _settings;

    [Inject]
    public void Construct(SettingsHolder settings)
    {
        _settings = settings;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_settings.Data.ForwardKey)) { print("Forward!"); }
        if (Input.GetKeyDown(_settings.Data.BackwardKey)) { print("Backward!"); }
    }
}
