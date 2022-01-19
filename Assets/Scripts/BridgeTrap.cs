using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrap : MonoBehaviour
{
    public GameObject Bridge; // ������Ʈ
    private Vector3 init_pos; // ó�� ��ġ��
    private bool set = true; // Update �۵�/���۵�

    // Bridge�� ó�� ��ġ init_pos�� �޾ƿ���
    private void Start()
    {
        init_pos = Bridge.GetComponent<Transform>().transform.position;
    }

    // Bridge�� ������ Update �۵� ����
    private void OnTriggerEnter(Collider other)
    {
        set = false;
    }

    // Bridge�� �������� �Ʒ��� ������
    private void OnTriggerStay(Collider other)
    {
        Bridge.transform.Translate(Vector3.down * Time.deltaTime);
    }

    // Bridge���� ������ Update �۵� ����
    private void OnTriggerExit(Collider other)
    {
        set = true;
    }

    // Bridge�� ó�� ��ġ�� ������
    private void Update()
    {
        if (set == true)
        {
            Bridge.transform.position = Vector3.Lerp(Bridge.transform.position, init_pos, Time.deltaTime);
        }
    }
}
