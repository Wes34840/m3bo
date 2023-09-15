using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerAudioPlayer : MonoBehaviour
{
    private float EmptySoundTimer = 0.3f;
    private AudioSource p_audioSource;
    [SerializeField] private AudioClip[] audioClips;
    internal void PlayEmptyGunSound()
    {
        EmptySoundTimer -= Time.deltaTime;
        if (EmptySoundTimer <= 0)
        {
            PlayAudio(AudioClips.Empty);

            EmptySoundTimer = 0.3f;
        }
        else
        {
            return;
        }
    }
    

    internal void PlayAudio(AudioClips clip)
    {
        p_audioSource.PlayOneShot(audioClips[(int)clip]);
    }
}
