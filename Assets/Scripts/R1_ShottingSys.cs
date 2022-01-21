using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Round1_Trap3 투석기함수
public class R1_ShottingSys : MonoBehaviour
{
    [SerializeField] Transform m_tfGunBody = null; // 투석기 바디
    [SerializeField] Transform m_tfHead = null; // 투석기 머리(바라보는방향) 
    [SerializeField] float m_range = 0f; // 탐지범위
    [SerializeField] LayerMask m_layerMask = 0; // 플레이어 레이어마스크변수
    [SerializeField] float m_spinSpeed = 0f; //적발견시 타게팅회전속도
    [SerializeField] float m_fireRate = 0f; //연사속도 변수
    float m_currentFireRate = 0f; //연산에 사용될 속도변수

    [SerializeField] Animator animator = null; //애니메이터 변수
    [SerializeField] GameObject catapult = null;
    //[SerializeField] private bool ani_trigger = false; // 애니메이션 재생트리거
    [SerializeField] GameObject stone = null; //돌 오브젝트
    [SerializeField] Transform stone_fire_Pos = null; //돌 발사위치
    [SerializeField] float stone_power = 10f;

    Transform m_tfTarget = null; //플레이어위치

    //주변 탐색함수
    void SearchEnemy()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_range, m_layerMask); //사정거리내에 있는 콜라이더검출
        Transform t_shortestTarget = null;

        //주변에 콜라이더가 있으면
        if (t_cols.Length > 0)
        {
            float t_shortestDistance = Mathf.Infinity;
            foreach (Collider t_colTarget in t_cols) //주변콜라이더만큼 반복문
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
        Debug.Log(m_tfTarget);
    }

    //스톤 프리팹 생성함수
    void Fire()
    {
        GameObject m_stone = Instantiate(stone, stone_fire_Pos.position, stone_fire_Pos.transform.rotation);
        m_stone.GetComponent<Rigidbody>().velocity = (m_stone.transform.up + m_stone.transform.forward) * stone_power;
    }

    ////돌 구면보간 함수 -> 돌로 이동후 삭제
    //void stone_Slerp()
    //{
    //    stone.transform.position = Vector3.Slerp(stone.transform.position, m_tfTarget.position, 0.1f);
    //}

 


    // Start is called before the first frame update
    void Start()
    {
        m_currentFireRate = m_fireRate;
        animator = catapult.GetComponent<Animator>();
        InvokeRepeating("SearchEnemy", 0f, 0.5f); //0.5초마다 반복호출        
    }

    // Update is called once per frame
    void Update()
    {        
        if (m_tfTarget == null)
        {
            m_tfGunBody.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
            animator.SetBool("R1_Anim_Spoon_Trigger_Bool", false); // 애니메이션 중지
        }
        else
        {
            //Debug.Log("적탐색완료");
            Quaternion t_loorRotation = Quaternion.LookRotation(m_tfTarget.position - m_tfHead.position);
            Vector3 t_euler = Quaternion.RotateTowards(m_tfGunBody.rotation, t_loorRotation, m_spinSpeed * Time.deltaTime).eulerAngles;

            m_tfGunBody.rotation = Quaternion.Euler(0, t_euler.y, 0);

            Quaternion t_fireRotation = Quaternion.Euler(0, t_loorRotation.eulerAngles.y, 0); //투석기가 봐라볼 방향변수

            if (Quaternion.Angle(m_tfGunBody.rotation, t_fireRotation) < 5f) //목표각이랑 현재각이 5도이하가되면 발사
            {
                m_currentFireRate -= Time.deltaTime; // 초당 한개씩 줄임
                if (m_currentFireRate <= 0)
                {
                    m_currentFireRate = m_fireRate;
                    //Debug.Log("발사");
                    animator.SetBool("R1_Anim_Spoon_Trigger_Bool", true); // 애니메이션 재생
                    Fire();
                }
            }

        }
    }
}
