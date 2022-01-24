using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap0_1_Trigger : MonoBehaviour
{
    public GameObject[] Trap0_1;
    // Start is called before the first frame update
    int count = 0;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            Trap0_1[1].gameObject.SetActive(true);
            Trap0_1[0].transform.GetComponent<Round2_Trap0_GoSpawn>().turnon = true;
            count++;
        }

        else if(other.tag == "round2_trap0_1")
        {
            Trap0_1[count].transform.GetComponent<Round2_Trap0_GoSpawn>().turnon = true;
            other.gameObject.SetActive(false);
        }
    }
}
