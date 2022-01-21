using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_Stone_Spawn : MonoBehaviour
{
    public Transform[] StoneSpawn;
    public GameObject Stone;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("stone_spawn", 1.5f,0.4f);   
        
    }

    public void cancel_invoke()
    {
        CancelInvoke("stone_spawn");
    }

    private void stone_spawn()
    {
        int random = Random.Range(0, StoneSpawn.Length);
        float random_x = Random.Range(StoneSpawn[0].position.x, StoneSpawn[5].position.x);
        Vector3 stoneSpawn = new Vector3(random_x, StoneSpawn[random].position.y, StoneSpawn[random].position.z);
        Instantiate(Stone, stoneSpawn,Quaternion.identity);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
