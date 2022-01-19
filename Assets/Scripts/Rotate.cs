using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float speed = 3.0f;         //회전속도
    private void Update()
    {
        Orbit_Rotation();
    }

    void Orbit_Rotation()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        //transform.Rotate(Vector3 EularAngle)
    }
}