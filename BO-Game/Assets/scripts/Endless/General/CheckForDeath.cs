using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForDeath : MonoBehaviour
{

    public GameObject MainUI;
    public GameObject EndScreen;
    public PlayerCombat Player;
    public AudioSource MusicBox;

    private bool hasTriggered;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerCombat>();
        MusicBox = GameObject.Find("MusicBox").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.health <= 0 && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(TriggerEndScreen());
        }
    }
    private IEnumerator TriggerEndScreen() 
    { 
        yield return new WaitForSeconds(2);
        MusicBox.volume = 0.02f;
        MainUI.SetActive(false);
        EndScreen.SetActive(true);
    }
}
