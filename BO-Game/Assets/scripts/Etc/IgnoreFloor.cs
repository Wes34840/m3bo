using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreFloor : MonoBehaviour
{

    Collider2D coll;
    Collider2D floor;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        floor = GameObject.Find("Floor").GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(coll.GetComponent<Collider2D>(), floor);
    }


}

