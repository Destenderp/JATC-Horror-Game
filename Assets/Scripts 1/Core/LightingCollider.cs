using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.Core;
using TL.UtilityAI.Actions;

public class LightingCollider : MonoBehaviour
{
    //Kinematic and Dynamic running into each other
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "PLAYER")
        {
            collision.GetComponent<Player>().setSpeed(5);
            Destroy(gameObject);
        }
    }
}
