using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [SerializeField]int health;
    [SerializeField]Transform mp;
    void Awake()
    {
        mp = gameObject.transform.Find("Movement Point");
        choosePosition();
    }
    void Update()
   {
        
   } 
    public void changeHealth(int change)
    {
        health += change;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void move()
    {
        
    }
    void choosePosition()
    {
        Vector2 position;
        position.x = UnityEngine.Random.Range(-5,5);
        position.y = UnityEngine.Random.Range(-5,5);
        mp.localPosition = position;
    }
    void followPlayer()
    {

    }
    void Attack()
    {

    }
}
