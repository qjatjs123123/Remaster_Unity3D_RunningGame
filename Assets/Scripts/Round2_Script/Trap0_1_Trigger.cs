using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap0_1_Trigger : MonoBehaviour
{
    public GameObject[] Trap0_1;
    public bool IsMiddle = false;
    // Start is called before the first frame update
    public int count = 0;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            Trap0_1[1].gameObject.SetActive(true);
            Trap0_1[0].transform.GetComponent<Round2_Trap0_GoSpawn>().turnon = true;
            
        }

        else if(other.tag == "round2_trap0_1")
        {
            if (!IsMiddle)
                other.gameObject.SetActive(false);
            else
            {
                count++;
                if (count == 1)
                {
                    Trap0_1[2].gameObject.SetActive(true);
                    Trap0_1[1].transform.GetComponent<Round2_Trap0_GoSpawn>().turnon = true;
                    
                }
                else if (count == 2)
                {
                    Trap0_1[2].transform.GetComponent<Round2_Trap0_GoSpawn>().turnon = true;

                }
            }
        }
    }
}
