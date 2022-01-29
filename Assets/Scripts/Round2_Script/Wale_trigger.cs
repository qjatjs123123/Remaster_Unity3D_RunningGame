using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wale_trigger : MonoBehaviour
{

    public GameObject whale;
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
           whale.transform.GetComponent<MovePara>().move_whale();
        }
    }


}
