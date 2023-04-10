using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LockCam : MonoBehaviour
{

    private Transform CamPos;
    private CameraControl CamCon;
    internal bool DoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Camera = GameObject.Find("Main Camera");
        CamPos = Camera.GetComponent<Transform>();
        CamCon = Camera.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CamPos.position.x >= transform.position.x && DoorOpen == false)
        {
            CamCon.followPlayer = false;
        }
        else if (DoorOpen == true) 
        {
            CamCon.followPlayer = true;
        }
        else
        {
            return;
        }
    }
}
