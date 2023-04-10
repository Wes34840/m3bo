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


    public bool PlayerIsVisible(bool FacingRight)
    {
        Vector3 Dir = Player.transform.position - transform.position; // find direction to shoot
        if (Dir.x > -3 && Dir.x < 3) // if player is close enough, awake
        {
            return true; 
        }
        else if ((Dir.x < 0 && FacingRight) || (Dir.x > 0 && !FacingRight)) // if Pinky is facing the other way, don't bother shooting raycast
        {
            return false;
        }

        RaycastHit2D[] Hits = Physics2D.RaycastAll(transform.position, Dir); // shoots raycast at player position
        Debug.DrawRay(transform.position, Dir, Color.green);
        for (int i = 0; i < Hits.Length; i++)
        {
            if (Hits[i].collider.CompareTag("Player")) // if a player is hit before a solid wall, pinky wakes up
            {
                return true;
                
            }
            else if (Hits[i].collider.CompareTag("Solid") == true) // if a solid wall is hit, check is discarded
            {
                break;
            }
            else
            {
                
            }
        }
        return false;
    }
    public float PosRelativeToPlayer()
    {

        float distance = (transform.position.x - Player.transform.position.x);
        return distance;
        
    }
    public float GetDirX(float distance)
    {
        if (distance > 0)
        {
            return -1;
        }
        else if (distance < 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
