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

    //�̵��Լ�
    private void Move()
    {
        //������ �����
       // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x,0f,cameraArm.forward.z).normalized, Color.red);

        //������ �� ����
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        
        animator.SetBool("isRun", isMove); //�ִϸ��̼� ���,�̵��̾������� idle�ִϸ��̼� �⺻ ���

        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized; // ���ȭ
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x; //�����̴� ������

            //characterBody.forward = lookForward;
            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * 5f;
        }        
    }

    private void Jump()
    {

    }

    //ī�޶� �̵��Լ� _ ��ũ��Ʈ�и���, ����� ���X �׽�Ʈ��
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        float x = camAngle.x - mouseDelta.y;

        //ī�޶� �ִ�ȸ������ ����
        if (x < 180f)//�������� ȸ���Ҷ�
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        //�Ʒ������� ȸ���Ҷ�
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
