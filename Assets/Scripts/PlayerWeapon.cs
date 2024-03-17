using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]int range,maxMagSize;
    [SerializeField]Vector2 damage;
    private int currentMagSize;
    [SerializeField]float reloadTime,accuracy;
    [SerializeField]GameObject bullet, bulletSpawner;
    void Update()
    {
        float distance = gameObject.GetComponentInParent<Player>().getDistance();
        float angle = Mathf.Log(accuracy,distance)*10;
        angle = -Mathf.Clamp(Mathf.Abs(angle), 2f, 35f);
        transform.localRotation = Quaternion.Euler(new Vector3(0,0,angle));
    }
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
            GameObject pro = Instantiate(bullet,bulletSpawner.transform.position, gameObject.transform.rotation);
            pro.GetComponent<Projectile>().setDamage(damage);
        }
        else
            Debug.Log("*Click*");
    }
}
