using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]int range,maxMagSize;
    [SerializeField]Vector2 damage;
    private int currentMagSize;
    [SerializeField]float reloadTime;
    [SerializeField]GameObject bullet, bulletSpawner;
    public int getMaxMagSize()
    {
        return maxMagSize;
    }
    public int getcurrentMagSize()
    {
        return currentMagSize;
    }
    public void reload(int reloadAmount)
    {
        currentMagSize += reloadAmount;
        Debug.Log("Gun has been reloaded");
    }
    public void shoot()
    {
        if(currentMagSize != 0)
        {
            currentMagSize--;
            GameObject pro = Instantiate(bullet,bulletSpawner.transform.position, GameObject.Find("Player").transform.rotation);
            pro.GetComponent<Projectile>().setDamage(damage);
        }
        else
            Debug.Log("*Click*");
    }
}
