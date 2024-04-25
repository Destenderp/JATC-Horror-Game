using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Intractable : MonoBehaviour
{
    [SerializeField]bool pitySystem;
    [SerializeField]static int tier1 = 20, tier2 = 70, tier3 = 100;
    [SerializeField] int bulletCount;
    [SerializeField] int batteryCount;
    [SerializeField] int healthCount;
    [SerializeField] string key;

    int random, teirOfStuff;
    void Start()
    {
        if(!pitySystem)
            setTrashCans();
    }
    void setTrashCans()
    {
        Debug.Log(gameObject.name);
        random = UnityEngine.Random.Range(0,100);
        Debug.Log(random);
        teirOfStuff = UnityEngine.Random.Range(0,100);
        if(random == 0 || random < 20)
        {
            setHealthCount();
        }
        else if(random >= 20 && random < 60)
            setBulletCount();
        else if(random >= 60 && random <=100)
            setBatteryCount();
    }
    public int getBulletCount()
    {
        return bulletCount;
    }
    public int getBatteryCount()
    {
        return batteryCount;
    }
    public int getHealthCount()
    {
        return healthCount;
    }
    public string getKey()
    {
        return key;
    }
    public void useInteractable()
    {
        Destroy(gameObject);
    }
    void setBulletCount()
    {
        if(teirOfStuff == 0 || teirOfStuff < tier1)
            bulletCount = UnityEngine.Random.Range(1,5);
        else if(teirOfStuff >= tier1 || teirOfStuff <= tier2)
            bulletCount = UnityEngine.Random.Range(5,15);
        else if(teirOfStuff >= tier2 || teirOfStuff <= tier3)
            bulletCount = UnityEngine.Random.Range(15,20);
    }
    void setHealthCount()
    {
        if(teirOfStuff == 0 || teirOfStuff < tier1)
            healthCount = UnityEngine.Random.Range(20,50);
        else if(teirOfStuff >= tier1 || teirOfStuff <= tier2)
            healthCount = UnityEngine.Random.Range(50,75);
        else if(teirOfStuff >= tier2 || teirOfStuff <= tier3)
            healthCount = 100;
    }
    void setBatteryCount()
    {
        Debug.Log("Setting Batteries!");
        if(teirOfStuff == 0 || teirOfStuff < tier1)
            batteryCount = UnityEngine.Random.Range(10,30);
        else if(teirOfStuff >= tier1 || teirOfStuff <= tier2)
            batteryCount = UnityEngine.Random.Range(31,70);
        else if(teirOfStuff >= tier2 || teirOfStuff <= tier3)
            batteryCount = UnityEngine.Random.Range(71,100);
    }
}
