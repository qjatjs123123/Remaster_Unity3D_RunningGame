using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject Bomb;
    public Transform BombSpawn;
    public float WaitTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountAttackDelay(WaitTime));
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountAttackDelay(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("adfdsa");
        Instantiate(Bomb, BombSpawn.position, Quaternion.identity);
        StartCoroutine(CountAttackDelay(WaitTime));
    }
}
