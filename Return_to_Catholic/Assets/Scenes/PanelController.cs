using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Inspector���� ������ �г� ����
    public GameObject targetPanel;

    // �г��� Ȱ��ȭ�ϴ� �޼���
    public void ShowPanel()
    {
        targetPanel.SetActive(true);
    }

    // �г��� ��Ȱ��ȭ�ϴ� �޼���
    public void HidePanel()
    {
        targetPanel.SetActive(false);
    }

    // �г��� ����ϴ� �޼��� (Ȱ��ȭ/��Ȱ��ȭ ��ȯ)
    public void TogglePanel()
    {
        targetPanel.SetActive(!targetPanel.activeSelf);
    }
}

