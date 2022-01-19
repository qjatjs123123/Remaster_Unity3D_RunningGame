using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forDebug : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F10))
            SceneManager.LoadScene("Round1");
        if (Input.GetKeyDown(KeyCode.F11))
            SceneManager.LoadScene("Round2");
        if (Input.GetKeyDown(KeyCode.F12))
            SceneManager.LoadScene("Round3");

        //1라운드 클리어위치 텔포
        if (Input.GetKeyDown(KeyCode.F6))
        {
            GameObject.FindWithTag("Player").GetComponent<reponse>().originPos = new Vector3(172, 108, 140);
        }
        //2라운드 클리어위치 텔포
        if (Input.GetKeyDown(KeyCode.F7))
        {
            GameObject.FindWithTag("Player").GetComponent<reponse>().originPos = new Vector3(71, 32, 100);
        }
        //3라운드 클리어위치 텔포
        if (Input.GetKeyDown(KeyCode.F8))
        {
            GameObject.FindWithTag("Player").GetComponent<reponse>().originPos = new Vector3(94, 40, 38);
        }
            

    }
}
