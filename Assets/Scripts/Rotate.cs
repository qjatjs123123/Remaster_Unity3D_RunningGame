using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float speed = 3.0f;         //ȸ���ӵ�
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