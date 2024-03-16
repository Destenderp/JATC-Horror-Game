using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intractable : MonoBehaviour
{
    [SerializeField] int bulletCount;
    public int getBulletCount()
    {
        return(bulletCount);
    }
    public void useInteractable()
    {
        Destroy(gameObject);
    }
}
