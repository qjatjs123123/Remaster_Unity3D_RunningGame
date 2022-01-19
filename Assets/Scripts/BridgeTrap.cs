using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrap : MonoBehaviour
{
    public GameObject Bridge; // 오브젝트
    private Vector3 init_pos; // 처음 위치값
    private bool set = true; // Update 작동/미작동

    // Bridge의 처음 위치 init_pos로 받아오기
    private void Start()
    {
        init_pos = Bridge.GetComponent<Transform>().transform.position;
    }

    // Bridge를 밟으면 Update 작동 중지
    private void OnTriggerEnter(Collider other)
    {
        set = false;
    }

    // Bridge에 서있으면 아래로 움직임
    private void OnTriggerStay(Collider other)
    {
        Bridge.transform.Translate(Vector3.down * Time.deltaTime);
    }

    // Bridge에서 나오면 Update 작동 시작
    private void OnTriggerExit(Collider other)
    {
        set = true;
    }

    // Bridge를 처음 위치로 움직임
    private void Update()
    {
        if (set == true)
        {
            Bridge.transform.position = Vector3.Lerp(Bridge.transform.position, init_pos, Time.deltaTime);
        }
    }
}
