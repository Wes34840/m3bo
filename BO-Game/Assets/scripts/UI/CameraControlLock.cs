using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CameraControlLock : MonoBehaviour
{

    [SerializeField] private Transform player;
    public bool followPlayer = true;

    private void Update()
    {
        if (followPlayer == true)
        {
            transform.position = new Vector3(player.position.x, player.position.y + 3.4f, -10) ;
        }
    }
}
