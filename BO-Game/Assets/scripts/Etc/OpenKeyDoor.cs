using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyDoor : MonoBehaviour
{

    private Collider2D coll;
    public GameObject parentDoor;
    private PlayerMovement player;
    private LockCam lockCam;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        lockCam = GameObject.Find("StaticCamPoint").GetComponent<LockCam>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.HasKeyRed == true)
            {
                parentDoor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                lockCam.DoorOpen = true;
            }
            else
            {
                return;
            }
        }

    }
}


