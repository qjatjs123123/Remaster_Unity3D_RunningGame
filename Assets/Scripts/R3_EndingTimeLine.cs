using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class R3_EndingTimeLine : MonoBehaviour
{
    [SerializeField] GameObject TimeLine;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject TimeLineCamera;
    [SerializeField] GameObject Player;

    [SerializeField] GameObject Final_Board;
    [SerializeField] GameObject timer;

    public Text Final_DeathCount;
    public Text Final_Time_Hour;
    public Text Final_Time_Min;
    public Text Final_Time_sec;

    private Text DeathCount;
    private Text Time_Hour;
    private Text Time_Min;
    private Text Time_sec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReceiveSignal()
    {
        DeathCount = GameObject.FindWithTag("count").GetComponent<Text>();
        Time_Hour = GameObject.FindWithTag("hour").GetComponent<Text>();
        Time_Min = GameObject.FindWithTag("min").GetComponent<Text>();
        Time_sec = GameObject.FindWithTag("sec").GetComponent<Text>();


        Debug.Log("������ �ε�");
        //Ÿ�̸� ����
        timer timer = GameObject.FindWithTag("timer").GetComponent<timer>();
        timer.TimerOn = false;

        //�ð�,����ī���� �ҷ�����
        Final_DeathCount.GetComponent<Text>().text = (int.Parse(DeathCount.GetComponent<Text>().text)).ToString();
        Final_Time_Hour.GetComponent<Text>().text = (int.Parse(Time_Hour.GetComponent<Text>().text)).ToString();
        Final_Time_Min.GetComponent<Text>().text = (int.Parse(Time_Min.GetComponent<Text>().text)).ToString();
        Final_Time_sec.GetComponent<Text>().text = (int.Parse(Time_sec.GetComponent<Text>().text)).ToString();



        //ĵ���� �ε� , ĳ���� ����
        Final_Board.SetActive(true);
        Player.SetActive(false);


              

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<BasicBehaviour>().enabled = false;
            Player.GetComponent<MoveBehaviour>().enabled = false;
            //Ŀ���������
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            MainCamera.SetActive(false);
            TimeLine.SetActive(true);
            TimeLineCamera.SetActive(true);
        }
    }
}


