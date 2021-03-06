using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2_Stone_Speed : MonoBehaviour
{
    public Rigidbody RB;
    GameObject DieMessage;
    GameObject Camera;
    GameObject Player;
    Animator animator;
    float random;
    // Start is called before the first frame update
    private void Awake()
    {
        random = Random.Range(50f, 100f);
    }
    void Start()
    {
        DieMessage = GameObject.FindGameObjectWithTag("DieMessage");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = Player.transform.GetComponent<Animator>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
            Destroy(gameObject, 1f);
    }


    // Update is called once per frame
    void Update()
    {
        
        RB.AddForce(Vector3.down * random);
    }
}
