using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerSpriteUpdater : MonoBehaviour
{
    private bool isCrouched = false;

    private Animator anim;
    private SpriteRenderer sprite;
    private bool isFacingRight;
    private PlayerAudioPlayer audioPlayer;
    private FirePointUpdate firePointUpdate;
    private enum MovementState { idle, walking, firing, crouching, crouchWalk, crouchFiring, dying, coolerDying }

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<PlayerAudioPlayer>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        firePointUpdate = GetComponentInChildren<FirePointUpdate>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void UpdateSprite(float dirX, float dirY, float velY, bool currentFace, float ammo)
    {
        isFacingRight = currentFace;

        MovementState state;

        if (isFacingRight)
        {
            // flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (!isFacingRight)
        {
            // flip the player.
            Flip();
        }

        if (dirX != 0) // player is walking
        {
            state = MovementState.walking;

            if (dirY < 0f && velY == 0) // if player is crouching, make player crouchwalk
            {
                state = MovementState.crouchWalk;
            }
        }
        else if (dirY < 0 && velY == 0) // checking stationary crouching input
        {
            state = MovementState.crouching;
            isCrouched = true;
            UpdatePointPosition();
            if (Input.GetButton("Fire1")) // firing while in crouched position
            {
                if (ammo > 0)
                {
                    state = MovementState.crouchFiring;
                }
                else
                {
                    // audioPlayer.PlayEmptyGunSound();
                }

            }
        }
        else // otherwise idle
        {
            state = MovementState.idle;
            isCrouched = false;
            UpdatePointPosition();
            if (Input.GetButton("Fire1"))
            {
                if (ammo > 0)
                {
                    state = MovementState.firing; // play idle firing animation
                }
                else
                {
                    // audioPlayer.PlayEmptyGunSound(); // play click sound effect, implying the gun is empty
                }
            }
        }
        anim.SetInteger("state", (int)state);

    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;  // player is no longer facing the direction it was facing according to the game

        transform.Rotate(0f, 180f, 0); // direction is mirrored
    }

    internal void ShowDeathSprite(float health)
    {
        if (health < -40) // if you take enough damage, you play the cooler death animation
        {
            //source.clip = CoolerDying; // self-explanetory
            //source.Play();
            anim.SetInteger("state", (int)MovementState.coolerDying);
        }
        else
        {
            //source.clip = Dying;
            //source.Play();
            anim.SetInteger("state", (int)MovementState.dying); // play normal death animation
        }
    }
    private void UpdatePointPosition() // this looks like a bad way of implementing it, but fuck it, it works for now
    {
        firePointUpdate.UpdatePosition(isCrouched);
    }
}
