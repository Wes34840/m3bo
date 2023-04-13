using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject Enemy;
    private Transform[] SpawnPoints = new Transform[6];
    public ScoreUpdate ScoreSystem;
    public AudioSource MusicBox;
    public AudioSource WaveSounds;

    [SerializeField] private int SpawnCount = 10;

    public int RequiredScore, WaveCount = 0;
    public bool WaveActive, HasSpawned, IsCurrentlyStarting = false;

    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            SpawnPoints[i] = transform.GetChild(i).GetComponent<Transform>(); // get all possible spawn points
        }
    }

    void Update()
    {
        if (WaveActive && !HasSpawned)
        {
            for (int i = 0; i < SpawnCount; i++)
            {
                int spawn = Random.Range(0, 6);
                Instantiate(Enemy, SpawnPoints[spawn].position, Quaternion.identity); // spawn enemy in random spawn point
            }
            HasSpawned = true; // all enemies have spawned
        }

        if (ScoreSystem.PlayerScore >= RequiredScore && WaveActive)
        {
            WaveActive = false;
        }
        else if (!WaveActive && !IsCurrentlyStarting)
        {
            StartCoroutine(StartNextRound());
            IsCurrentlyStarting = true;
        }

    }

    private IEnumerator StartNextRound()
    {
        MusicBox.volume = 0.05f; 
        WaveSounds.Play();

        yield return new WaitForSeconds(2);
        MusicBox.volume = 0.1f;

        WaveCount++;
        SpawnCount = 8 + (2 * WaveCount); // every wave has 2 more enemies
        RequiredScore += (500 * SpawnCount); // required score is the total amount of score you get by killing all enemies
        
        WaveActive = true;
        HasSpawned = false;

    }

}
