using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOn : MonoBehaviour
{
    // Public method to load the specified scene
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MAIN_Scene");
    }
}
