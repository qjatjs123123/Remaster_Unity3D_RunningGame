using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePara : MonoBehaviour
{

    public Rigidbody RB;
    public float speed;
    public Transform tr;
    bool turnon = false;
    // Start is called before the first frame update
    public void Start()
    {
        //RB.AddForce(Vector3.up * 500f);
       // RB.AddForce(Vector3.right * 500f);
    }
    public void move_whale()
    {
        
        RB.constraints = RigidbodyConstraints.None;
        RB.AddForce(Vector3.up * 450f);
        RB.AddForce(Vector3.right * 600f);
    }

    // Update is called once per frame
    void Update()
    {
        
            //transform.right = RB.velocity;
    }


}
