using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_for : MonoBehaviour
{

    Vector3 pos; //������ġ
    float delta = 6.0f; // ��(��)�� �̵������� (x)�ִ밪
    float speed = 1.0f; // �̵��ӵ�
    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        // �¿� �̵��� �ִ�ġ �� ���� ó���� �̷��� ���ٿ� ���ְ� �ϳ׿�.
        transform.position = v;
    }

}
