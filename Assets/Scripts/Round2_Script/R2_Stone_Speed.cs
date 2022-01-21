using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2_Stone_Speed : MonoBehaviour
{
    public Rigidbody RB;
    float random;
    // Start is called before the first frame update
    private void Awake()
    {
        random = Random.Range(50f, 100f);
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
        RB.AddForce(Vector3.down * random);
    }
}
