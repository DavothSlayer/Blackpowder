using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI;
    private bool _paused = false;

    // Hides the Pause Menu on start. Very clever Veeti. -Shad //
    private void Awake() => pauseMenuUI.SetActive(false);

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) TogglePause();
    }

    public void TogglePause()
    {        
        _paused = !_paused; // Set the boolean to its opposite value. Imagine like *-1. -Shad //
        pauseMenuUI.SetActive(_paused); // Feed the _paused boolean directly to the method. -Shad //
        Time.timeScale = _paused ? 0f : 1f; // Is _paused? Then set to 0f, else set to 1f. -Shad //

        Cursor.lockState = _paused ? CursorLockMode.None : CursorLockMode.Locked; // Is _paused? Then free the cursor, else lock it. -Shad //
    }
}
