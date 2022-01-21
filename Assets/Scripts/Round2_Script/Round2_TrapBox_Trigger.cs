using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_TrapBox_Trigger : MonoBehaviour
{
    public GameObject Trap2;
    public Round2_Shooting_Spear RSS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpearBoxes")
        {       
            Trap2.transform.GetComponent<Round2_Trap_Mover>().turnon = false;
        }
        else if (other.tag == "Player")
        {
            RSS.Cancel_Invoke();
        }


    }
}
