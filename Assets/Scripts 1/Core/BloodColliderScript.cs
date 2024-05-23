using System.Collections;
using System.Collections.Generic;
using TL.Core;
using UnityEngine;

public class BloodColliderScript : MonoBehaviour
{

    //Kinematic and Dynamic running into each other
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player>().setSpeed(3);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
   
        if (collision.gameObject.name == "PLAYER")
        {
            collision.GetComponent<Player>().setSpeed(5);
            Destroy(gameObject);
        }
    }
}
