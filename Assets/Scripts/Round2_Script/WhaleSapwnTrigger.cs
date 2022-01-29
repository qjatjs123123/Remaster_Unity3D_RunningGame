using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleSapwnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "whale")
        {
            Transform tr = other.gameObject.transform.GetComponent<MovePara>().tr;
            Rigidbody RB = other.gameObject.transform.GetComponent<Rigidbody>();

            Vector3 v = new Vector3(tr.position.x, tr.position.y, tr.position.z);
            RB.constraints = RigidbodyConstraints.FreezeAll;
            
            other.gameObject.transform.position = v;

            other.gameObject.transform.rotation = tr.rotation;

            
        }
    }
}
