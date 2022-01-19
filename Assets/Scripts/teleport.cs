using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    public GameObject TeleportA;
    public GameObject TeleportB;
    void Start()
    {
           
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            
            Vector3 pos;
            pos = TeleportA.transform.position;
            reponse re = GameObject.Find("Player").GetComponent<reponse>();
            re.originPos = pos;
            TeleportA.SetActive(true);
            TeleportB.SetActive(false);
        }
    }
}
