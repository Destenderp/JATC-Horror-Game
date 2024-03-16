using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField]int damage, range, currentMagSize, maxMagSize;
    [SerializeField]float reloadTime;
    [SerializeField]GameObject bullet;
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
            Instantiate(bullet,transform.position, Quaternion.identity);
        }
        else
            Debug.Log("*Click*");
    }
}
