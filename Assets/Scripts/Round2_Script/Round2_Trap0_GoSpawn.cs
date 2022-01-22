using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_Trap0_GoSpawn : MonoBehaviour
{
    public bool turnon = false;
    public Transform Target_pos;
    public float delta = 20.0f; // ��(��)�� �̵������� (x)�ִ밪
    public float speed = 30.0f; // �̵��ӵ�

    int num= 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!turnon)
            return;

        Vector3 v = new Vector3(Target_pos.position.x + num, Target_pos.position.y, Target_pos.position.z);
        transform.position = Vector3.MoveTowards(transform.position, v, 8f * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - Target_pos.position.x) > 5.0f && transform.position.x>= Target_pos.position.x)
            num = -30;
        else if(Mathf.Abs(transform.position.x - Target_pos.position.x) > 0.5f && transform.position.x <= Target_pos.position.x)
                num = 30;

    }
}
