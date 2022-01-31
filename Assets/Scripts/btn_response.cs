using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btn_response : MonoBehaviour
{
    public GameObject player;
    public GameObject DieMessage;
    public Animator animator;
    public GameObject Camera;
    public GameObject timerCanvas;
    public Text DeathCount ;

    public GameObject[] Trap0;
    public Transform Trap0_Spawn1;
    public Transform Trap0_Spawn2;
    public GameObject Trap0_Trigger;
    public GameObject[] blade_trap;



    //private void Update()
    //{
    //    player = GameObject.FindWithTag("Player");
    //    animator = player.GetComponent<Animator>();
    //    Camera = GameObject.FindWithTag("MainCamera");
    //    timerCanvas = GameObject.FindWithTag("timer");
    //}

    public void respawn_trap()
    {
        for(int i = 0; i < Trap0.Length; i++)
        {
            Trap0[i].transform.GetComponent<Round2_Trap0_GoSpawn>().turnon = false;
            if (i < Trap0.Length - 1)
            {
                Vector3 v = new Vector3(Trap0_Spawn1.position.x, Trap0_Spawn1.position.y, Trap0_Spawn1.position.z);
                Trap0[i].transform.position = v;
            }
            else
            {
                Vector3 v = new Vector3(Trap0_Spawn2.position.x, Trap0_Spawn2.position.y, Trap0_Spawn2.position.z);
                Trap0[i].transform.position = v;
            }
        }
        for (int i = 0; i < blade_trap.Length; i++)
        {
            blade_trap[i].SetActive(false);          
        }
        Trap0[0].SetActive(true);
        Trap0[1].SetActive(false);
        Trap0[2].SetActive(false);
        Trap0_Trigger.transform.GetComponent<Trap0_1_Trigger>().count = 0;

        
            
    }


    public void response_click()
    {
        respawn_trap();

        player = GameObject.FindWithTag("Player");
        animator = player.GetComponent<Animator>();
        Camera = GameObject.FindWithTag("MainCamera");
        timerCanvas = GameObject.FindWithTag("timer");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator.Play("Locomotion", -1, 0);
        player.GetComponent<reponse>().ResetFalling();
        DieMessage.SetActive(false);
        Camera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = true;
        player.GetComponent<MoveBehaviour>().enabled = true;
        DeathCount.GetComponent<Text>().text = (int.Parse(DeathCount.GetComponent<Text>().text)+1).ToString();
        timer ti = timerCanvas.GetComponent<timer>();
        ti.TimerOn = true;       

    }

}
