using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_Trap0_GoSpawn : MonoBehaviour
{
    public bool turnon = false;
    public Transform Target_pos;
    public bool IsUP = false;

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
        if(IsUP)
            transform.Translate(-Vector3.up * 8f * Time.deltaTime);
        if (!IsUP)
            transform.Translate(Vector3.forward * 8f * Time.deltaTime);




    }
}
