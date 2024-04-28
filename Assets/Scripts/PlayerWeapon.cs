using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]GameObject bullet, bulletSpawner;
    [SerializeField]Vector2 damage;
    private int currentMagSize;
    [SerializeField]int range,maxMagSize;
    [SerializeField]float reloadTime;
    [SerializeField]bool isRecharged;
    void Awake() 
    {
        isRecharged = true;
    }
    public int getMaxMagSize()
    {
        return maxMagSize;
    }
    public int getcurrentMagSize()
    {
        return currentMagSize;
    }
    public void setCurrentMagSize(int bullets)
    {
        currentMagSize = bullets;
    }
    public void reload(int reloadAmount)
    {
        currentMagSize += reloadAmount;
        Debug.Log("Gun has been reloaded");
    }
    public void shoot(Animator anim)
    {
        if(currentMagSize != 0 && isRecharged == true)
        {
            anim.SetTrigger("Shoot");
            isRecharged = false;
            currentMagSize--;
            GameObject pro = Instantiate(bullet,bulletSpawner.transform.position, gameObject.transform.rotation);
            pro.GetComponent<Projectile>().setDamage(damage);
            StartCoroutine(shootDelay());
        }
        else if(currentMagSize == 0)
            Debug.Log("*Click*");
    }
    IEnumerator shootDelay()
    {
        Debug.Log("Delaying Fire");
        yield return new WaitForSeconds(.5f);
        isRecharged = true;
    }
}
