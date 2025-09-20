using UnityEngine;
using UnityEngine.SceneManagement;

    public class StartButton : MonoBehaviour
    {
    //Start button, with field if you want to quickly change the scene name for testing -Veeti//
    [SerializeField] private string sceneName = "NameOfScene";
    public void OnStartButtonPressed()
        {
            SceneManager.LoadScene(sceneName);
        }
    }