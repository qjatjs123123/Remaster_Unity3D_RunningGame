using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Round1_Trap3 �������Լ�
public class R1_ShottingSys : MonoBehaviour
{
    [SerializeField] Transform m_tfGunBody = null; // ������ �ٵ�
    [SerializeField] Transform m_tfHead = null; // ������ �Ӹ�(�ٶ󺸴¹���) 
    [SerializeField] float m_range = 0f; // Ž������
    [SerializeField] LayerMask m_layerMask = 0; // �÷��̾� ���̾��ũ����
    [SerializeField] float m_spinSpeed = 0f; //���߽߰� Ÿ����ȸ���ӵ�
    [SerializeField] float m_fireRate = 0f; //����ӵ� ����
    float m_currentFireRate = 0f; //���꿡 ���� �ӵ�����

    [SerializeField] Animator animator = null; //�ִϸ����� ����
    [SerializeField] GameObject catapult = null;
    //[SerializeField] private bool ani_trigger = false; // �ִϸ��̼� ���Ʈ����
    [SerializeField] GameObject stone = null; //�� ������Ʈ
    [SerializeField] Transform stone_fire_Pos = null; //�� �߻���ġ
    [SerializeField] float stone_power = 10f;

    Transform m_tfTarget = null; //�÷��̾���ġ

    //�ֺ� Ž���Լ�
    void SearchEnemy()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_range, m_layerMask); //�����Ÿ����� �ִ� �ݶ��̴�����
        Transform t_shortestTarget = null;

        //�ֺ��� �ݶ��̴��� ������
        if (t_cols.Length > 0)
        {
            float t_shortestDistance = Mathf.Infinity;
            foreach (Collider t_colTarget in t_cols) //�ֺ��ݶ��̴���ŭ �ݺ���
            {
                float t_distance = Vector3.SqrMagnitude(transform.position - t_colTarget.transform.position);
                if (t_shortestDistance > t_distance)
                {
                    t_shortestDistance = t_distance;
                    t_shortestTarget = t_colTarget.transform;
                }
            }
        }

        m_tfTarget = t_shortestTarget;
    }

    //���� ������ �����Լ�
    void Fire()
    {
        GameObject m_stone = Instantiate(stone, stone_fire_Pos.position, stone_fire_Pos.transform.rotation);
        m_stone.GetComponent<Rigidbody>().velocity = (m_stone.transform.up + m_stone.transform.forward) * stone_power;
    }

    ////�� ���麸�� �Լ� -> ���� �̵��� ����
    //void stone_Slerp()
    //{
    //    stone.transform.position = Vector3.Slerp(stone.transform.position, m_tfTarget.position, 0.1f);
    //}

 


    // Start is called before the first frame update
    void Start()
    {
        m_currentFireRate = m_fireRate;
        animator = catapult.GetComponent<Animator>();
        InvokeRepeating("SearchEnemy", 0f, 0.5f); //0.5�ʸ��� �ݺ�ȣ��        
    }

    // Update is called once per frame
    void Update()
    {        
        if (m_tfTarget == null)
        {
            m_tfGunBody.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
            animator.SetBool("R1_Anim_Spoon_Trigger_Bool", false); // �ִϸ��̼� ����
        }
        else
        {
            //Debug.Log("��Ž���Ϸ�");
            Quaternion t_loorRotation = Quaternion.LookRotation(m_tfTarget.position - m_tfHead.position);
            Vector3 t_euler = Quaternion.RotateTowards(m_tfGunBody.rotation, t_loorRotation, m_spinSpeed * Time.deltaTime).eulerAngles;

            m_tfGunBody.rotation = Quaternion.Euler(0, t_euler.y, 0);

            Quaternion t_fireRotation = Quaternion.Euler(0, t_loorRotation.eulerAngles.y, 0); //�����Ⱑ ���� ���⺯��

            if (Quaternion.Angle(m_tfGunBody.rotation, t_fireRotation) < 5f) //��ǥ���̶� ���簢�� 5�����ϰ��Ǹ� �߻�
            {
                m_currentFireRate -= Time.deltaTime; // �ʴ� �Ѱ��� ����
                if (m_currentFireRate <= 0)
                {
                    m_currentFireRate = m_fireRate;
                    //Debug.Log("�߻�");
                    animator.SetBool("R1_Anim_Spoon_Trigger_Bool", true); // �ִϸ��̼� ���
                    Fire();
                }
            }

        }
    }
}
