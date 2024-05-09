using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField]SceneManager s_SceneManager;
    void OnTriggerEnter2D(Collider2D other) 
    {
        Player temp = other.gameObject.GetComponent<Player>();
        if(temp != null)
            s_SceneManager.playerWin();
    }
}
