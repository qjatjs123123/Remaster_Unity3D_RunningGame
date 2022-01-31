using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    Transform BombEndSpawn;
    GameObject DieMessage;
    GameObject Camera;
    GameObject Player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject BoomEndRespawn = GameObject.FindGameObjectWithTag("BoomEndSpawn");
        BombEndSpawn = BoomEndRespawn.transform;
        DieMessage = GameObject.FindGameObjectWithTag("DieMessage");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = Player.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, BombEndSpawn.position, 0.5f);
        transform.Translate(-Vector3.forward * 10f*Time.deltaTime);
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
