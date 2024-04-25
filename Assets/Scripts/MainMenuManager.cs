using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]InputAction c_QuitGame;
    void Start()
    {
        c_QuitGame.Enable();
        c_QuitGame.performed += quitGame;
    }
    public void StartButton()
    {
        Debug.Log("You Started the Game");
        SceneManager.LoadScene("Main Level");
    }
    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
    void quitGame(InputAction.CallbackContext ctx)
    {
        Debug.Log("I Quit the Game");
        Application.Quit();
    }
    
}
