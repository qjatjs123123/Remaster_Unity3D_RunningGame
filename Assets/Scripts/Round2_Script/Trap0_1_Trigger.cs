using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap0_1_Trigger : MonoBehaviour
{
    public GameObject[] Trap0_1;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            for (int i = 0; i < Trap0_1.Length; i++)
            {
                Trap0_1[i].gameObject.SetActive(true);
                Trap0_1[i].transform.GetComponent<Round2_Trap0_GoSpawn>().turnon = true;
            }
        }

        else if(other.tag == "round2_trap0_1")
        {
            other.gameObject.SetActive(false);
        }
    }
}
