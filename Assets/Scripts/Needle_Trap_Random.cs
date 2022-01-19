using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle_Trap_Random : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool trapTrigger = false;

   // [SerializeField] private string Trigger_On = "Anim_Needle_Trap_Bounce";
    //[SerializeField] private string Trigger_Off = "Anim_Needle_Trap_Idle";


    //private void Update()
    //{
    //    InvokeRepeating("PlayAni", 5, 1);
    //}

    
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("PlayAni", Random.Range(2, 4));
    }


    void PlayAni()
    {

        //Debug.Log("애니메이션 재생");
        //ani.Play("Anim_TrapNeddle_Play");
        if (trapTrigger)
        {
            //ani.Play(Trigger_On, 0, 0.0f);
            animator.SetInteger("Traptrigger", 1);
            trapTrigger = false;
        }
        else
        {
            // ani.Play(Trigger_Off, 0, 0.0f);
            animator.SetInteger("Traptrigger", 0);
            trapTrigger = true;
        }
        Invoke("PlayAni", Random.Range(2, 4));
    }

}
