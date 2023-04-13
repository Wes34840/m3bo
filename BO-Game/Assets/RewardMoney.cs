using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMoney : MonoBehaviour
{

    private EnemyPinky ParentScript;
    private WaveModeScript Player;
    private bool HasAwarded = false;

    // Start is called before the first frame update
    void Start()
    {
        ParentScript = GetComponent<EnemyPinky>();
        Player = GameObject.FindWithTag("Player").GetComponent<WaveModeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ParentScript.health <= 0 && !HasAwarded)
        {
            Player.money += 10;
            HasAwarded = true;
        }
    }
}
