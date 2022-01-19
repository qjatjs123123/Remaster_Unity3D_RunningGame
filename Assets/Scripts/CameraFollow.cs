using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Transform cameraArm;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPostition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPostition;

        LookAround();
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;

        //카메라 최대회전범위 제한
        if (x < 180f)//위쪽으로 회전할때
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        //아래쪽으로 회전할때
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
