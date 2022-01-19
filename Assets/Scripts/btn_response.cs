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

    //private void Update()
    //{
    //    player = GameObject.FindWithTag("Player");
    //    animator = player.GetComponent<Animator>();
    //    Camera = GameObject.FindWithTag("MainCamera");
    //    timerCanvas = GameObject.FindWithTag("timer");
    //}

    public void response_click()
    {
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
