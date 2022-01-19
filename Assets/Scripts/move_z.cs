using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_z : MonoBehaviour
{
    Vector3 pos; //������ġ
    [SerializeField] private float delta = 6.5f; // ��(��)�� �̵������� (x)�ִ밪
    [SerializeField] private float speed = 0.8f; // �̵��ӵ�
    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        // �¿� �̵��� �ִ�ġ �� ���� ó���� �̷��� ���ٿ� ���ְ� �ϳ׿�.
        transform.position = v;
    }
}
