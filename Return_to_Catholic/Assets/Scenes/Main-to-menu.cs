using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    // Setting 버튼을 눌렀을 때 호출되는 메서드
    public void Loadstart_Menu_Scene()
    {
        // "Settings" 씬을 로드
        SceneManager.LoadScene("Start-Menu");
    }
}
