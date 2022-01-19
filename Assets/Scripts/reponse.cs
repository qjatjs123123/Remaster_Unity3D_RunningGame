using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reponse : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 originPos = new Vector3();
    void Start()
    {
       
    }

    // Update is called once per frame
    public void ResetFalling()
    {
        transform.position = originPos;
    }
}
