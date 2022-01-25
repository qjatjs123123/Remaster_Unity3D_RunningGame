using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTattach : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pTransform;
    public float rotSpeed = 3f;
    public bool trigger;
    private bool trigger1;

    private void OnTriggerEnter(Collider other)
    {
        trigger1 = true;
    }
    private void Update()
    {
        if(trigger1 && trigger == true)
            pTransform.position = new Vector3(pTransform.position.x, pTransform.position.y, pTransform.position.z + rotSpeed*Time.deltaTime);
        if(trigger1 && trigger == false)
            pTransform.position = new Vector3(pTransform.position.x, pTransform.position.y, pTransform.position.z - rotSpeed*Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        trigger1 = false;
    }
}
