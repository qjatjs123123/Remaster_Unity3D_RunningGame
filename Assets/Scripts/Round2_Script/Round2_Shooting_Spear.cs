using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_Shooting_Spear : MonoBehaviour
{
    public GameObject Player;
    GameObject[] SpearTrap;
    public GameObject[] Spears;
    public int Shootnum;
    // Start is called before the first frame update
    private void Awake()
    {
        SpearTrap = GameObject.FindGameObjectsWithTag("SpearTrap");
    }
    void Start()
    {
        InvokeRepeating("Shooting_Spear", 1f,1f);   
    }
    private void Shooting_Spear()
    {
        
        for(int i = 0; i<Shootnum;i++)
        {
            int random = Random.Range(0, 64);
            SpearTrap[random].transform.GetChild(1).gameObject.SetActive(true);
            SpearTrap[random].transform.GetComponent<Animation>().Play("Anim_SpearTrap_Play");
            SpearTrap[random].transform.GetComponent<Animation>().wrapMode = WrapMode.Once;
            
        }
    }
    public void Cancel_Invoke()
    {
        CancelInvoke("Shooting_Spear");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
