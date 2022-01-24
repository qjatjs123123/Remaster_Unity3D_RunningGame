using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2_Stone_Delete : MonoBehaviour
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
        if (other.tag == "Water")
            Destroy(gameObject, 1f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Water")
            Destroy(gameObject, 1f);
    }
}
