using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTriggers : MonoBehaviour
{
    [SerializeField]TutorialManager TM;
    [SerializeField]string TutorialText;
    [SerializeField]bool tutorialEnd;
    //If something enters a tutorial trigger it loads the main menu
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            if(tutorialEnd)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            TM.tutorial(TutorialText, true);
        }
    }
}
