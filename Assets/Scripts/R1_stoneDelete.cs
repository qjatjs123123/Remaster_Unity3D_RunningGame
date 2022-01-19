using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R1_stoneDelete : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Terrain")
        {
           Destroy(gameObject,2);
        }

        else if (collision.collider.tag == "Player")
        {
            Debug.Log("투석기맞고 사망");
            GameObject.FindWithTag("_GM").GetComponent<game_over>().GameOver();            
        }

    }
}
