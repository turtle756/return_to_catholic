using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    // Setting ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void Loadstart_Menu_Scene()
    {
        // "Settings" ���� �ε�
        SceneManager.LoadScene("Start-Menu");
    }
}
