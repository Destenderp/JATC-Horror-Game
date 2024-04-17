using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        Player temp = other.gameObject.GetComponent<Player>();
        if(temp != null)
            SceneManager.LoadScene(2);
    }
}
