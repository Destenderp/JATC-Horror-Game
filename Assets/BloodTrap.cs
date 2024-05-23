using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTrap : MonoBehaviour
{
    [SerializeField] bool canDamage;
    [SerializeField] float damage;
    Player player;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        player = other.gameObject.GetComponent<Player>();
        player.setSpeed(1);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(canDamage)
            player.takeDamage(damage);
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        player = other.gameObject.GetComponent<Player>();
        player.resetSpeed();
        Destroy(gameObject);
    }

}
