using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
