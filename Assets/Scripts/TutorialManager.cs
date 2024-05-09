using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System;
using Kino;

public class TutorialManager : MonoBehaviour
{
    string tutorialText;
    [SerializeField]GameObject tutorialPane;
    [SerializeField]TextMeshProUGUI text;
    void Awake()
    {
        SetTutorialPane(false);
    }
    //Toggles the tutorial pane based on input
    public void tutorial(string text, bool paneEnable)
    {
        SetTutorialText(text);
        SetTutorialPane(paneEnable);
    }
    //Sets the tutorial text based on a string
    public void SetTutorialText(string text)
    {
        this.text.text = text;
    }
    //Method overload that does not require a string to run
    public void SetTutorialPane(bool paneEnable)
    {
        tutorialPane.SetActive(paneEnable);
    }
}
