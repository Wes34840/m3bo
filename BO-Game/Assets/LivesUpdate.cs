using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesUpdate : MonoBehaviour
{
    private TMP_Text ScoreField;
    public PlayerCombat combatScript;
    public int PlayerLives;

    // Start is called before the first frame update
    void Start()
    {
        combatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        ScoreField = GetComponent<TMP_Text>();
    }

    void Update()
    {
        PlayerLives = combatScript.health;
        ScoreField.text = "Health : " + PlayerLives;
    }
}
