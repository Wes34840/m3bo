using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    private Collider2D coll;
    private Rigidbody2D rb;

    private GameObject door;
    private Collider2D floor;

    private GameObject destroyThis;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        door = GameObject.FindWithTag("Door");
        floor = GameObject.Find("Floor").GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(coll, floor);
        Physics2D.IgnoreCollision(door.GetComponent<Collider2D>(), floor);

        destroyThis = GameObject.Find("DestroyThis");
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision) // when player stand on button
    {
        if (collision.gameObject.CompareTag("Player"))
            {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; // removes freeze on Y axis but keeps freeze on X position. making it go through the floor

            door.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; ; ; // same as with the door

            Destroy(destroyThis, 0.5f);
        }
        else
        {
            Physics2D.IgnoreCollision(coll, collision.collider);
        }
    }
    
}
