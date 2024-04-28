using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTriggers : MonoBehaviour
{
    [SerializeField]TutorialManager TM;
    [SerializeField]string TutorialText;
    [SerializeField]bool tutorialEnd;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Player>() != null)
        {
            if(tutorialEnd)
                SceneManager.LoadScene(0);
            TM.tutorial(TutorialText, true);
        }
    }
}
