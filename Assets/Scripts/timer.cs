using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    public Text[] ClockText;    
    public bool TimerOn = true;
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

            ClockText[0].text = ((int)time / 3600).ToString(); //��
            ClockText[1].text = (((int)time / 60%60)).ToString(); // ��
            ClockText[2].text = (((int)time % 3600)%60).ToString(); //��
        }

        
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F1))
        {
            menu_bool = !menu_bool;

            if (menu_bool)
            {
                //Ŀ���������
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                menu_Image.SetActive(true);
            }
            else
            {
                //Ŀ�����
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
