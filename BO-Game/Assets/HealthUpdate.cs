using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUpdate : MonoBehaviour
{

    private TMP_Text ScoreField;

    // Start is called before the first frame update
    void Start()
    {
        ScoreField = GetComponent<TMP_Text>();
    }

    public void UpdateUI(int health)
    {
        ScoreField.text = "Health: " + health + "%";
    }
    
}
