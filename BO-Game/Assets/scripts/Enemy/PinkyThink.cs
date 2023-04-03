using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class PinkyThink : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public float PosRelativeToPlayer()
    {

        float distance = (transform.position.x - Player.transform.position.x);
        return distance;
        
    }
    public float GetDirX(float distance)
    {
        if (distance > 2)
        {
            return -1;
        }
        else if (distance < -2)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
