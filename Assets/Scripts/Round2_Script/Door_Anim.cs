using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Anim : MonoBehaviour
{
    public GameObject[] trap;
    
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
        if(other.tag == "Player")
        {
            for(int i = 0; i< trap.Length; i++)
            {
                trap[i].SetActive(true);
                trap[i].transform.GetComponent<Animation>().Play("Anim_BladeTrap01_Play");
            }
        }
    }
}
