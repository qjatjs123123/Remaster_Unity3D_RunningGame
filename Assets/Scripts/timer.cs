using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    public Text[] ClockText;    
    public bool TimerOn = false;
    private float time;
    public GameObject DieMessage;
    public GameObject menu_Image;
    public bool menu_bool;
    public bool death = false;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            time += Time.deltaTime;

            ClockText[0].text = ((int)time / 3600).ToString(); //시
            ClockText[1].text = (((int)time / 60%60)).ToString(); // 분
            ClockText[2].text = (((int)time % 3600)%60).ToString(); //초
        }

        
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F1))
        {
            menu_bool = !menu_bool;

            if (menu_bool)
            {
                //커서잠금해제
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                menu_Image.SetActive(true);
            }
            else
            {
                //커서잠금
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                menu_Image.SetActive(false);
            }
            if (DieMessage.activeSelf == true)
            {
                death = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        

    }
}
