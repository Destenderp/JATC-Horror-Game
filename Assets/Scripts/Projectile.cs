using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damage;
    //Randomly determines an amount of damage based on the damage vector2
    public void setDamage(Vector2 damage)
    {
        this.damage = -(int)Random.Range(damage.x, damage.y);
        Debug.Log(this.damage);
    }
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*50);
        StartCoroutine(destroyBullet());
    }
    //After 4 seconds the bullet is destroyed
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    //When it enters a collision it determines what it hits and runs logic based on that interaction
    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        CameraTrap trap = other.gameObject.GetComponent<CameraTrap>();
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            //If it hits an enemy they take damage
            enemy.changeHealth(damage);
        }
        if(trap != null)
        {
            //If it hits a trap (Camera) it is going to disable it
            trap.disableCamera();
            Debug.Log("Collided with camera");
        }
        Destroy(gameObject);
    }
}
