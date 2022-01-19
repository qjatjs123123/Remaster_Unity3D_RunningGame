using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField]private Transform characterBody;
    [SerializeField]private Transform cameraArm;
    
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //LookAround();
        Move();
        //Move2();
    }

    //이동함수
    private void Move()
    {
        //전진축 디버깅
       // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x,0f,cameraArm.forward.z).normalized, Color.red);

        //움직임 축 설정
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        
        animator.SetBool("isRun", isMove); //애니메이션 재생,이동이없을때는 idle애니메이션 기본 재생

        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized; // 평면화
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x; //움직이는 방향계산

            //characterBody.forward = lookForward;
            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * 5f;
        }        
    }

    private void Jump()
    {

    }

    //카메라 이동함수 _ 스크립트분리함, 현재는 사용X 테스트중
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
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
