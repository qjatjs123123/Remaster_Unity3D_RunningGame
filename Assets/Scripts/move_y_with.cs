using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_y_with : MonoBehaviour
{
 


    public Transform bTransform;
    public Transform pTransform;

    // Start is called before the first frame update
    Vector3 pos; //현재위치
    public float delta; // 좌(우)로 이동가능한 (x)최대값
    float speed = 0.8f; // 이동속도
    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        // 좌우 이동의 최대치 및 반전 처리를 이렇게 한줄에 멋있게 하네요.
        transform.position = v;
    }
    private void OnCollisionEnter(Collision collision)
    {
        pTransform.parent = bTransform; //오브젝트의 페어런트를 pTransform으로 지정
    }
    private void OnCollisionExit(Collision collision)
    {
        pTransform.parent = null; //오브젝트의 페어런트를 해제합니다.
    }
}
