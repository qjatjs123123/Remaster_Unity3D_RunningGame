using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_x_with : MonoBehaviour
{
    public Transform bTransform;
    public Transform pTransform;

    // Start is called before the first frame update
    Vector3 pos; //������ġ
    public float delta; // ��(��)�� �̵������� (x)�ִ밪
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
