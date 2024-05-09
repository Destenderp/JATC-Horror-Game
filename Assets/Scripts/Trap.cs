using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField]float cooldownTime;
    [SerializeField]GameObject recording;

    [SerializeField] bool canDamage;
    [SerializeField]bool isdDamaged = false;
    //If the player enters the trap area they take damage and the camera is disabled temperarily
    void OnTriggerStay2D(Collider2D other) 
    {
        Player temp = other.gameObject.GetComponent<Player>();
        Debug.LogWarning(temp);
        if(temp != null && canDamage == true)
        {
            temp.takeDamage(damage);
            recording.SetActive(false);
            canDamage = false;
            cooldownTime = 10;
        } 
    }
    //Updates the cooldown time unless it has been damaged
    void Update()
    {
        if(cooldownTime > 0)
            cooldownTime -= Time.deltaTime;
        if(cooldownTime <= 0 && isdDamaged == false)
        {
            canDamage = true;
            recording.SetActive(true);
        }
    }
    //Perminantly turns off the camera
    public void disableCamera()
    {
        canDamage = false;
        isdDamaged = true;
        recording.SetActive(false);
    }

}
