using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_game_over : MonoBehaviour
{
    GameObject DieMessage;
    GameObject Camera;
    GameObject Player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        DieMessage = GameObject.FindGameObjectWithTag("DieMessage");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = Player.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DieMessage = GameObject.Find("Canvas").transform.Find("DieMessage").gameObject;
            DieMessage.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Camera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = false;
            Player.GetComponent<MoveBehaviour>().enabled = false;
            animator.Play("Locomotion", -1, 0);
            animator.Play("Falling Back Death", -1, 0);

            Player.GetComponent<MoveBehaviour>().PlaySound("DIE");
        }
    }
}
