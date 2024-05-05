using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFloor : MonoBehaviour
{
    // 바닥 타일 프리팹
    public GameObject 바닥타일프리팹;

    // 이동 속도 및 플레이어
    public float 이동속도 = 5.0f;
    public Transform 플레이어;

    // 타일의 길이
    private float 타일길이 = 32.0f; // 타일 길이 설정

    // 두 개의 타일을 저장할 리스트
    private List<GameObject> 타일리스트 = new List<GameObject>();

    // 타일 생성 주기를 위한 딜레이 시간 (초)
    public float 생성딜레이 = 1.0f;

    // 타일 생성 딜레이 제어를 위한 플래그
    private bool 타일생성가능 = true;

    // 초기화
    void Start()
    {
        // 바닥 타일 프리팹이 설정되어 있는지 확인합니다.
        if (바닥타일프리팹 == null)
        {
            Debug.LogError("바닥 타일 프리팹이 설정되어 있지 않습니다!");
            return;
        }

        // 타일을 2개 생성하여 리스트에 추가
        for (int i = 0; i < 2; i++)
        {
            GameObject 타일 = Instantiate(바닥타일프리팹);
            타일.transform.position = new Vector3(i * 타일길이, 타일.transform.position.y, 타일.transform.position.z);
            타일리스트.Add(타일);
        }
    }

    void Update()
    {
        // 각 타일을 플레이어 이동 속도에 맞춰 왼쪽으로 이동시킵니다.
        foreach (var 타일 in 타일리스트)
        {
            타일.transform.Translate(Vector3.left * 이동속도 * Time.deltaTime);
        }

        // 타일 생성이 가능한지 확인 후 타일을 재배치합니다.
        if (타일생성가능 && 타일리스트[0].transform.position.x + 타일길이 < 플레이어.position.x)
        {
            GameObject 첫번째타일 = 타일리스트[0];
            타일리스트.RemoveAt(0);

            // 타일을 플레이어의 앞으로 재배치
            첫번째타일.transform.position = new Vector3(타일리스트[1].transform.position.x + 타일길이, 첫번째타일.transform.position.y, 첫번째타일.transform.position.z);
            타일리스트.Add(첫번째타일);

            // 타일 생성 딜레이 코루틴 실행
            StartCoroutine(타일생성딜레이());
        }
    }

    // 타일 생성에 딜레이를 주는 코루틴
    IEnumerator 타일생성딜레이()
    {
        타일생성가능 = false;
        yield return new WaitForSeconds(생성딜레이);
        타일생성가능 = true;
    }
}
