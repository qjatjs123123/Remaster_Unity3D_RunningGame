using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_Stone_Trigger : MonoBehaviour
{
    public GameObject Trap1;
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
        if (other.tag == "Player")
            Trap1.transform.GetComponent<Round2_Stone_Spawn>().cancel_invoke();
    }
}
