using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R0_BtnControll : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    
    public GameObject menu_Image; // 메뉴이미지
    public GameObject canvas; // 캔버스
    public GameObject finalCanvas;

    public GameObject StartCam;
    public GameObject MainCam;
    public GameObject startMessage;
    public GameObject timer;
    public GameObject Player;
    public Transform tr;
    public GameObject DieMessage;

    public btn_response btn_Response;



    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }

    public void GameStart()
    {

        SceneManager.LoadScene("Round2");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
   
    public void ReturnBtn()
    {
        menu_Image.SetActive(false);
        timer ti = GameObject.Find("Canvas").GetComponent<timer>();
        ti.menu_bool = !(ti.menu_bool);

        if (ti.death == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            //커서잠금해제    
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoTitleBtn()
    {
        SceneManager.LoadScene("Start_Menu");
        finalCanvas = GameObject.FindWithTag("timer");
        finalCanvas.SetActive(false);
        canvas.SetActive(false);



    }


}

