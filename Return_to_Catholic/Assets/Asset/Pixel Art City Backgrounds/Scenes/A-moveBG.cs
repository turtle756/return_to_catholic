using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 배경이동 : MonoBehaviour
{
    // 배경 이동 속도
    public float 속도;

    // 현재 배경의 x 위치
    private float 현재위치;

    // 배경의 최종 목적지와 초기 위치
    public float 도착지점;
    public float 초기위치;

    void Update()
    {
        // 현재 배경의 위치를 갱신합니다.
        현재위치 = transform.position.x;
        현재위치 += 속도 * Time.deltaTime;
        transform.position = new Vector3(현재위치, transform.position.y, transform.position.z);

        // 배경이 도착지점에 도달하면 초기 위치로 재설정합니다.
        if (현재위치 <= 도착지점)
        {
            현재위치 = 초기위치;
            transform.position = new Vector3(현재위치, transform.position.y, transform.position.z);
        }
    }
}

