using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round2_Trap_Mover : MonoBehaviour
{
    public GameObject Player;
    public GameObject TrapBoxes;
    public Transform TR;
    public bool turnon = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!turnon)
        {
            return;
        }
        
        Vector3 Player_pos = Player.transform.position;
        Vector3 TrapBoxex_pos = TrapBoxes.transform.position;
        Vector3 Target_pos = new Vector3(transform.position.x, transform.position.y , Player_pos.z + 20f);

        if (TrapBoxex_pos.z < Player_pos.z + 30f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target_pos, 5f* Time.deltaTime);

        }

    }
}
