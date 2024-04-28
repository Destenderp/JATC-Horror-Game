using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]string key;
    public void checkKey(List<string> keys)
    {
        foreach (string key in keys)
        {
            if(key == this.key)
            {
                Destroy(gameObject);
                return;
            }
        }
        Debug.Log("You do not have the required key");  
    }
    public string getKey()
    {
        return key;
    }
}
