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
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void TutorialButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }
    void quitGame(InputAction.CallbackContext ctx)
    {
        Debug.Log("I Quit the Game");
        Application.Quit();
    }
    public void toggleFullscreen(bool isActive)
    {
        if(isActive)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        if(!isActive)
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }
    
}
