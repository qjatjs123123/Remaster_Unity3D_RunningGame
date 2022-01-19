using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBrd : MonoBehaviour
{
    public float speed;
    private bool trigger;
    public GameObject board;
    public Transform bTransform;
    public Transform pTransform;
    public float maxpos, minpos;
    // Start is called before the first frame update
    void Start()
    {
        trigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( board.transform.position.z < maxpos && trigger )
            board.transform.Translate(Vector3.forward * Time.deltaTime*speed);
        if( board.transform.position.z > minpos && !trigger )
            board.transform.Translate(Vector3.back * Time.deltaTime*speed);
        if (board.transform.position.z >= maxpos)
            trigger = false;
        else if (board.transform.position.z <= minpos)
            trigger = true;
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
