using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_y_with : MonoBehaviour
{
 


    public Transform bTransform;
    public Transform pTransform;

    // Start is called before the first frame update
    Vector3 pos; //������ġ
    public float delta; // ��(��)�� �̵������� (x)�ִ밪
    float speed = 0.8f; // �̵��ӵ�
    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        // �¿� �̵��� �ִ�ġ �� ���� ó���� �̷��� ���ٿ� ���ְ� �ϳ׿�.
        transform.position = v;
    }
    private void OnCollisionEnter(Collision collision)
    {
        pTransform.parent = bTransform; //������Ʈ�� ��Ʈ�� pTransform���� ����
    }
    private void OnCollisionExit(Collision collision)
    {
        pTransform.parent = null; //������Ʈ�� ��Ʈ�� �����մϴ�.
    }
}
