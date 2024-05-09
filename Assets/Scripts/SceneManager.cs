using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    //If the player dies it loads the death screen
    public void playerDeath()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("You Lost");
    }
    //If the player wins it loads the win scene
    public void playerWin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("You Win");
    }
    public void mainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
