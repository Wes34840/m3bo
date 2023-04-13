using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUpdate : MonoBehaviour
{
    private TMP_Text TextField;
    public EnemySpawner WaveLogic;

    // Start is called before the first frame update
    void Start()
    {
        TextField = GetComponent<TMP_Text>();
        WaveLogic = GameObject.Find("WaveLogic").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        TextField.text = "Wave " + WaveLogic.WaveCount;
    }
}
