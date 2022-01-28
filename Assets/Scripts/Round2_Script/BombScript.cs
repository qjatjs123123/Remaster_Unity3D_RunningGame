using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    Transform BombEndSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject BoomEndRespawn = GameObject.FindGameObjectWithTag("BoomEndSpawn");
        BombEndSpawn = BoomEndRespawn.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, BombEndSpawn.position, 0.5f);
        transform.Translate(-Vector3.forward * 10f*Time.deltaTime);
    }
}
