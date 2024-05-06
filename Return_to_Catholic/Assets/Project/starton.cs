using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 버튼을 눌렀을 때 호출되는 메서드
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MAIN_Scene");
    }

    public void QuitGame()
    {
        // 에디터에서 디버그 로그로 종료 시도 확인
        Debug.Log("Game is exiting...");

        // 게임 종료
        Application.Quit();
    }

    public void LoadSettingsScene()
    {
        // "Settings" 씬을 로드
        SceneManager.LoadScene("MAIN-Munu");
    }
}
