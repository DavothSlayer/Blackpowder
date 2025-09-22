using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject panelToShow; // Assign this in the Inspector

    //Shows settings panel when button is pressed -Veeti//
    public void ShowPanel()
    {
        if (panelToShow != null)
        {
            panelToShow.SetActive(true);
        }
    }
}
