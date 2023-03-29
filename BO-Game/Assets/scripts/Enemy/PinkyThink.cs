using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinkyThink : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    public int PosRelativeToPlayer()
    {
        if (transform.position.x <= (Player.transform.position.x - 4)) // if player is to the left
        {
            return 1;
        }
        else if (transform.position.x >= (Player.transform.position.x - 4))
        {
            return -1;
        }
        return 0;
    }
}
