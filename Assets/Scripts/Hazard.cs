using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this will check to see if the object we are colliding with has a PlayerController component
        //if so, we assign the reference to our variable tempPlayer, otherwise the refernce is NULL
        PlayerController tempPlayer = collision.gameObject.GetComponent<PlayerController>();

        //if we don't have a player, this will be null, and we don't call OnReset

        if(tempPlayer != null)
        {
            tempPlayer.OnDeath();
        }
        //Alternative player check
        //if(collision.gameObject.CompareTag("Player"))


    }
}
