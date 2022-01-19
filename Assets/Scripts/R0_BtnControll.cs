using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R0_BtnControll : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    
    public GameObject menu_Image; // �޴��̹���
    public GameObject canvas; // ĵ����
    public GameObject finalCanvas;

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
        SceneManager.LoadScene("Round1");
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
            //Ŀ���������    
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

        if (SceneManager.GetActiveScene().name == "Start_Menu")
        {
            Destroy(canvas);
        }
    }


}

