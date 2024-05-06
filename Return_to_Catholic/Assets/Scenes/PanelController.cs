using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Inspector에서 설정할 패널 변수
    public GameObject targetPanel;

    // 패널을 활성화하는 메서드
    public void ShowPanel()
    {
        targetPanel.SetActive(true);
    }

    // 패널을 비활성화하는 메서드
    public void HidePanel()
    {
        targetPanel.SetActive(false);
    }

    // 패널을 토글하는 메서드 (활성화/비활성화 전환)
    public void TogglePanel()
    {
        targetPanel.SetActive(!targetPanel.activeSelf);
    }
}

