using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private 필드를 직렬화(Serialization)하도록 설정
    //[SerializeField] Transform playerCamera = null;
    //[SerializeField] float mouseSensitivity = 3.5f;
    //[SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    //[SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    //float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    Animator animator;

    




    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    void Update()
    {
       // UpdateMouseLook();
        UpdateMovement();
    }

    ////마우스 이동, 카메라회전함수
    //void UpdateMouseLook()
    //{
    //    Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    //    currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

    //    cameraPitch -= currentMouseDelta.y * mouseSensitivity;
    //    cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

    //    playerCamera.localEulerAngles = Vector3.right * cameraPitch;
    //    transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    //}


    //이동 함수
    void UpdateMovement()
    {

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        bool isMove = targetDir.magnitude != 0;
        animator.SetBool("isRun", isMove); //애니메이션 재생,이동이없을때는 idle애니메이션 기본 재생

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        //Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;
        //controller.Move(velocity * Time.deltaTime);



        ////발소리재생
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        //{
        //    footSteps.Play();
        //    //Debug.Log("play");
        //}

        //else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        //{
        //    footSteps.Stop();
        //    //Debug.Log("stop");
        //}

    }
}
