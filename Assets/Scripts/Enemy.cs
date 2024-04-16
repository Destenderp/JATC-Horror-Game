using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    [SerializeField]int health;
    [SerializeField]float speed;
    [SerializeField]Transform mp, ecp;

    Vector3 enemy;

    [SerializeField]LayerMask wallMask;

    void Awake()
    {
        mp = gameObject.transform.Find("Movement Point");
        ecp = gameObject.transform.Find("Enemy Check Point");
        wallMask = LayerMask.GetMask("Wall");
        choosePosition();
    }
    void Update()
   {
        move();
        checkWall();
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
        transform.Translate(Vector2.up*Time.deltaTime* speed);
    }
    void choosePosition()
    {
        enemy = gameObject.transform.position;
        Vector2 position;
        position.x = UnityEngine.Random.Range(-100,100);
        position.y = UnityEngine.Random.Range(-100,100);
        float radAngle = Mathf.Atan2(enemy.y - position.y, enemy.x - position.x);
        float degAngle = Mathf.Rad2Deg * radAngle;
        transform.rotation = Quaternion.Euler(0,0,degAngle);
    }
    void checkWall()
    {
        Vector2 rayCast = new Vector2(Vector2.up.x, Vector2.up.y + 1);
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position, transform.up, 1.5f,  wallMask);
        RaycastHit2D hitEnemy = Physics2D.Raycast(ecp.transform.up, transform.up, 10,  LayerMask.GetMask("Enemy"));
        if(hitEnemy == true)
        {
            Debug.Log("I hit an enemy");
            choosePosition();
        }
        if(hitWall == true)
        {
            Debug.Log("I hit a wall");
            choosePosition();
        }
    }
    void followPlayer()
    {

    }
    void Attack()
    {

    }
}
