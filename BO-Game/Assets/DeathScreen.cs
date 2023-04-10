using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject DeathScreenUI;
    public GameObject StatGUI;

    public PlayerCombat player;
    private bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (player.health == 0 && isDead == false)
        {
            StartCoroutine(TriggerDeathScreen());
        }
        else
        {
            
        }
    }
    
    private IEnumerator TriggerDeathScreen()
    {
        yield return new WaitForSeconds(2);
        StatGUI.SetActive(false);
        DeathScreenUI.SetActive(true);
    }
}
