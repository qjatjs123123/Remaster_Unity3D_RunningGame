using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrap : MonoBehaviour
{
    public float rotSpeed = 25f;
    public string direction = "x";
    public int changeRotate = 1;
    void Update()
    {
        self_Rotation();
    }

    void self_Rotation()
    {
        

        if (direction == "x")
            transform.Rotate(new Vector3(rotSpeed * Time.deltaTime* changeRotate, 0, 0));
        else if (direction == "y")
            transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime* changeRotate, 0));
        else if (direction == "z")
            transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime* changeRotate));
    }
}
