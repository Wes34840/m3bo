using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    private Collider2D coll;
    public GameObject endScreen;
    private AudioSource MusicBox;
    public AudioClip EndMusic;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        MusicBox = GameObject.Find("MusicBox").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        endScreen.SetActive(true);
        MusicBox.clip = EndMusic;
        MusicBox.Play();
    }

}
