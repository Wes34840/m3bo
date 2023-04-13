using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreOnEnd : MonoBehaviour
{
    private TMP_Text TextField;
    public ScoreUpdate ScoreUI;

    private void Start()
    {
        TextField = GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        TextField.text = "Your Score was: " + ScoreUI.PlayerScore;
    }
}
