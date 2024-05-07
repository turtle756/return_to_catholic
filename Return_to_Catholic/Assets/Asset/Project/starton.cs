using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MAIN_Scene");
    }

    public void QuitGame()
    {
        // �����Ϳ��� ����� �α׷� ���� �õ� Ȯ��
        Debug.Log("Game is exiting...");

        // ���� ����
        Application.Quit();
    }

    public void LoadSettingsScene()
    {
        // "Settings" ���� �ε�
        SceneManager.LoadScene("MAIN-Munu");
    }
}
