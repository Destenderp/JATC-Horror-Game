using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField]float cooldownTime;
    [SerializeField]GameObject recording;
    bool canDamage;
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
    void Update()
    {
        if(cooldownTime > 0)
            cooldownTime -= Time.deltaTime;
        if(cooldownTime <= 0)
        {
            canDamage = true;
            recording.SetActive(true);
        }
    }

}
