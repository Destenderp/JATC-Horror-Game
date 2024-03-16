using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damage;
    // Update is called once per frame
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
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            enemy.changeHealth(damage);
        }
        Destroy(gameObject);
    }
}
