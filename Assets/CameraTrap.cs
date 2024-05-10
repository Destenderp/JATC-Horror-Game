using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrap : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField]float cooldownTime;
    [SerializeField]bool isDamaged = false;
    [SerializeField]GameObject recording;

    [SerializeField] bool canDamage;
    void Update()
    {
        if(cooldownTime > 0)
            cooldownTime -= Time.deltaTime;
        if(cooldownTime <= 0 && isDamaged == false)
        {
            canDamage = true;
            recording.SetActive(true);
        }
    }
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
    public void disableCamera()
    {
        canDamage = false;
        isDamaged = true;
        recording.SetActive(false);
    }
}
