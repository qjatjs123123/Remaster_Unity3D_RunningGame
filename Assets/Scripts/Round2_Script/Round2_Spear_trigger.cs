using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_Spear_trigger : MonoBehaviour
{
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
        if (other.tag == "Spear")
        {
            other.gameObject.SetActive(false);
            
        }
        //other.transform.position = new Vector3(0,0,0);
    }
}
