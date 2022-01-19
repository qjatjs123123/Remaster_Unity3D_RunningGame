using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R1_FinaleCutScene : MonoBehaviour
{
    [SerializeField] GameObject TimeLine;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject TimeLineCamera;

    

    private void Start()
    {
        
    }

    public void ReceiveSignal()
    {
        Debug.Log("¾À·Îµå");
        SceneManager.LoadScene("Round2");
        //SceneManager.LoadScene("Round3");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MainCamera.SetActive(false);
            TimeLine.SetActive(true);
            TimeLineCamera.SetActive(true);
        }
    }
}
