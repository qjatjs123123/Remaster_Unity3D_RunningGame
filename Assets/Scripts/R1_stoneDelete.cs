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
            Debug.Log("������°� ���");
            GameObject.FindWithTag("_GM").GetComponent<game_over>().GameOver();            
        }

    }
}
