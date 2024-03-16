using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]int health;
    public void changeHealth(int change)
    {
        health += change;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
