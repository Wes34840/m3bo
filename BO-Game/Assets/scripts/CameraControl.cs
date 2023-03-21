using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Transform player;

    
    private void Update()
    {

        // Camera only follows player when they are in the middle of the screen and doesn't go back right
        if (player.transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(player.position.x, 5, -10);

        }
    }
}
