using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointUpdate : MonoBehaviour
{
    public void UpdatePosition(bool isCrouched)
    {

        if (isCrouched)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -0.2f);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0f);
        }
    }
}
