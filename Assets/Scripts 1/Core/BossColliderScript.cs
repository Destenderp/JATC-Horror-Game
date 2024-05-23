using System;
using System.Collections;
using System.Collections.Generic;
using TL.Core;
using TL.UtilityAI.Actions;
using Unity.VisualScripting;
using UnityEngine;

public class BossColliderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Stats.level == 4)
        {
            if (collision.gameObject.name == "Player")
            {
                if (Attack.chokeEnabled == false)
                {
                    Attack.chokeEnabled = true;
                    Attack.isPlayerFrozen = true;
                    collision.GetComponent<Player>().setSpeed(0);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Attack.isPlayerFrozen = false;
        try
        {
            Stats.player[0].setSpeed(5);
        }
        catch(NullReferenceException e)
        {
            Debug.LogWarning("Player is missing!");
        }
    }

    
}
