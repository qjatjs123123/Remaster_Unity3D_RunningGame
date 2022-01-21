using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class game_over : MonoBehaviour
{
    public GameObject DieMessage;
    public GameObject Player;
    public GameObject Camera;
    public Animator animator;



    private void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
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
        else if (col.tag == "Water")
        {
            Debug.Log("¹°");
            Destroy(gameObject, 1);

        }
    }

    public void GameOver() // ÇÁ¸®ÆÕ¿ë
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
