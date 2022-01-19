using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrap : MonoBehaviour
{
    public Transform player;
    private Vector3 back;
    // Start is called before the first frame update
    private void Start()
    {
        back = new Vector3(11, 30, 100);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        player.position = back;
    }
}
